namespace CTDS.CaseManagement.Application.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Linq.Dynamic;

    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.Database.Context;
    using CTDS.Database.Models.CaseManagement;
    using CTDS.Common.ExtensionMethods;
    using CTDS.CaseManagement.Contracts.Enums;
    using CTDS.CaseManagement.Contracts.Dto;

    public class CaseRepository : BaseRepository<Case>, ICaseRepository
    {

        private readonly CTDSContext CTDSContext;

        public CaseRepository()
        {
            CTDSContext = new CTDSContext();
        }

        public int FindCaseCount()
        {
            try
            {
                return CTDSContext.Case.Count();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Dictionary<string,int> FindFilteredCaseCount()
        {
            try
            {
                var a = CTDSContext.CaseStatus.AsQueryable()
                    .Join(CTDSContext.CaseInformation.AsQueryable(),
                    cs => cs.CaseId, ci => ci.CaseId,
                    (cs, ci) => new { cs.Status, ci.Priority })
                    .GroupBy(cs => cs.Status).ToList();

                var filteredList = new Dictionary<string, int>();
                foreach (var item in a)
                {
                    var processing = item.GroupBy(x => x.Priority).ToList();
                    foreach(var priority in processing)
                    {
                        string status = item.Key.ToString();
                        string key = status + priority.Key.ToString();
                        
                        filteredList.Add(key, priority.Count());
                    }
                }
                return filteredList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public int FindCasesInLastSevenDays()
        {
            DateTime date = DateTime.Now.AddDays(-6);
            try
            {
                return CTDSContext.Case.Where(c => c.CreatedOn >= date).Count();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public List<int> FindCasesPerDayLastWeek()
        {
            List<int> caseCountList = new List<int>();

            DateTime date = DateTime.Now.AddDays(-6);
            try
            {
                for(DateTime i = date.Date; i <= DateTime.Now.Date; i = i.AddDays(1).Date)
                {
                    int count = CTDSContext.Case.Where(c => c.CreatedOn == i).Count();
                    caseCountList.Add(count);
                }
                return caseCountList;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public List<Case> GetAllFilteredCases(int index, string sort)
        {
            List<Case> cases;
            try
            {
                using (var context = new CTDSContext())
                {
                    int maxRows = 3;
                    var query = context.Case;
                    cases = query.CustomOrderBy(sort).Skip((index - 1) * maxRows).Take(maxRows).ToList();
                }
                return cases;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CaseTableDto> GetAllCasesWithQuery(List<QueryDto> queries)
        {
            try
            {
                var expression = QueryBuilder(queries);
                var caseTableDtos = (from mcase in CTDSContext.Case
                                     join caseStatus in CTDSContext.CaseStatus on mcase.Id equals caseStatus.CaseId
                                     join caseInformation in CTDSContext.CaseInformation on mcase.Id equals caseInformation.CaseId
                                     join client in CTDSContext.Client on mcase.Id equals client.CaseId
                                     join notes in CTDSContext.Notes on mcase.Id equals notes.CaseId
                                     select new CaseTableDto
                                     {
                                         Id = mcase.Id,
                                         CaseId = mcase.CaseId,
                                         Status = caseStatus.Status,
                                         Priority = caseInformation.Priority,
                                         CreatedOn = mcase.CreatedOn,
                                         Description = caseInformation.Description,
                                         Client = client.ClientIdentifier,
                                         Notes = notes.NotesByCpa
                                     })
                            .Where(expression)
                            .ToList();
                return caseTableDtos;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TODO making generic using  private Expression<Func<TClass,bool>> QueryBuilder<TClass>(string query)
        private Expression<Func<CaseTableDto,bool>> QueryBuilder(List<QueryDto> queries)
        {
            Expression finalBody = Expression.Constant(true);
            var parameter = Expression.Parameter(typeof(CaseTableDto), "selectedCase");

            for (int i = 0;i<queries.Count;++i)
            {
                var propertyName = queries[i].Property;
                if(String.IsNullOrEmpty(queries[i].Value))
                {
                    continue;
                }
                var constantValues=queries[i].Value.Split(',').ToList();
                Expression orBody = Expression.Constant(false);
                for(int j =0;j<constantValues.Count;++j)
                {
                    var constantValue = constantValues[j];
                    var member = Expression.Property(parameter, propertyName);
                    var memberType = member.Type;
                    ConstantExpression constant = null;
                    if (memberType.IsEnum)
                    {
                        var instance = Activator.CreateInstance(memberType);
                        var enumType = Enum.Parse(instance.GetType(), constantValue);
                        constant = Expression.Constant(enumType);
                    }
                    else
                    {
                        constant = Expression.Constant(constantValue);
                    }

                    var body = Expression.Equal(member, constant);
                    orBody = Expression.OrElse(body, orBody);
                }
                   finalBody = Expression.AndAlso(orBody, finalBody);

            }
            
            var finalExpression= Expression.Lambda<Func<CaseTableDto, bool>>(finalBody, parameter);
            return finalExpression;
        }

    }
}