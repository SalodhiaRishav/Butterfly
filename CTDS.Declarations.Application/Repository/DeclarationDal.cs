namespace CTDS.Declarations.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using CTDS.Database.Context;
    using CTDS.Common.ExtensionMethods;
    using CTDS.Declarations.Application.Mapper;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Application.Repository.Interface;
    using CTDS.Declarations.Application.Mapper.Interface;
    using System.Linq.Expressions;
    using CTDS.Database.Models.Declarations;

    public class DeclarationDal : IDeclarationDal
    {
        private readonly IDatabaseMapper Mapper;
        public DeclarationDal(IDatabaseMapper mapper)
        {
            Mapper = mapper;
        }

        public Guid AddDeclaration(DeclarationDto declarationDto)
        {
            Guid success;
            
            try
            {
                using(var context = new CTDSContext())
                {
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    var newDeclaration = context.Declaration.Add(declaration);
                    context.SaveChanges();

                    success = newDeclaration.DeclarationId;
                }
                return success;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DeclarationDto GetDeclarationById(Guid id)
        {
            DeclarationDto declarationDto = new DeclarationDto();
            try
            {
                using(var context = new CTDSContext())
                {
                    var declaration = context.Declaration.Find(id);
                    declarationDto = Mapper.DeclarationToDto(declaration);
                }
                return declarationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<DeclarationDto> GetAllDeclarations(int index, string sort)
        {
            IEnumerable<DeclarationDto> declarationDtoList;
            try
            {
                using(var context = new CTDSContext())
                {
                    int maxRows = 3;
                    var query = context.Declaration;
                    var declarationList = query.CustomOrderBy(sort).Skip((index - 1) * maxRows).Take(maxRows).ToList();
                    declarationDtoList = Mapper.DeclarationListToDtoList(declarationList);
                }
                return declarationDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<DeclarationDto> GetAllDeclarations()
        {
            IEnumerable<DeclarationDto> declarationDtoList;
            try
            {
                using (var context = new CTDSContext())
                {
                    var declarationList = context.Declaration.ToList();
                    declarationDtoList = Mapper.DeclarationListToDtoList(declarationList);
                }
                return declarationDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool EditDeclaration(DeclarationDto declarationDto)
        {
            bool response;
            try
            {
                using (var context = new CTDSContext())
                {
                    //_context.Declaration.Log = s => { System.Diagnostics.Debug.WriteLine(s); };
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    context.Declaration.AddOrUpdate(declaration);
                    context.SaveChanges();
                    response = true;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddReference(ReferenceDto reference)
        {
            try
            {
                using(var context = new CTDSContext())
                {
                    var data = Mapper.DtoToReferenceModel(reference);
                    context.Reference.AddOrUpdate(d => d.ReferenceId,data);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ReferenceDto> GetReferenceData(Guid id)
        {
            IEnumerable<ReferenceDto> refData;
            try
            {
                using(var context = new CTDSContext())
                {
                    var data = context.Reference.Where(x => x.DeclarationId == id).ToList();
                    refData = Mapper.ReferenceListToDtoList(data);
                }
                return refData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetCount()
        {
            int count = 0;
            try
            {
                using(var context = new CTDSContext())
               {
                    count = context.Declaration.Count(); 
               }
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetCountForLastSevenDays()
        {
            int count = 0;
            DateTime date = DateTime.Now.AddDays(-6);
            try
            {
                using(var context = new CTDSContext())
                {
                    count = context.Declaration.Where(x => x.CreatedOn >= date).Count();
                }
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<int> FindPerDayDeclarationCount()
        {
            List<int> declarationCountList = new List<int>();

            DateTime date = DateTime.Now.AddDays(-6);
            try
            {
                using (var context = new CTDSContext())
                {
                    for (DateTime i = date.Date; i <= DateTime.Now.Date; i = i.AddDays(1).Date)
                    {
                        int count = context.Declaration.Where(c => c.CreatedOn == i).Count();
                        declarationCountList.Add(count);
                    }
                    return declarationCountList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SendToCustom(DeclarationDto declarationDto)
        {
            bool result = false;
            try
            {
                using (var context = new CTDSContext())
                {
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    context.Declaration.AddOrUpdate(declaration);
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FilterDeclarationsDto GetAllDeclarationsWithQuery(List<QueryDto> queries, int pageNumber, int maxRowsPerPage)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    FilterDeclarationsDto filterDeclarationsDto = new FilterDeclarationsDto();
                    var expression = QueryBuilder(queries);
                    var filteredDeclarations= context.Declaration
                                .Where(expression)
                                .ToList();
                    filterDeclarationsDto.TotalCount = filteredDeclarations.Count;
                    
                    var perPageFilteredDeclarations = filteredDeclarations.Skip((pageNumber - 1) * maxRowsPerPage).Take(maxRowsPerPage).ToList();
                    var perPageFilteredDeclarationDtos = Mapper.DeclarationListToDtoList(perPageFilteredDeclarations).ToList();
                    filterDeclarationsDto.Declarations = perPageFilteredDeclarationDtos;
                    return filterDeclarationsDto;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TODO making generic using  private Expression<Func<TClass,bool>> QueryBuilder<TClass>(string query)
        private Expression<Func<Declaration, bool>> QueryBuilder(List<QueryDto> queries)
        {
            Expression finalBody = Expression.Constant(true);
            var parameter = Expression.Parameter(typeof(Declaration), "selectedDeclaration");
            if (queries != null)
            {
                for (int i = 0; i < queries.Count; ++i)
                {
                    var propertyName = queries[i].Property;
                    if (queries[i].Values == null || queries[i].Values.Count == 0)
                    {
                        continue;
                    }

                    var constantValues = queries[i].Values;
                    Expression orBody = Expression.Constant(false);
                    if (queries[i].ValueDataType == "StringMatch")
                    {
                        var constantValue = constantValues[0];
                        var member = Expression.Property(parameter, propertyName);
                        ConstantExpression constant = Expression.Constant(constantValue);
                        var body = Expression.Equal(member, constant);
                        orBody = Expression.OrElse(body, orBody);
                    }
                    else if (queries[i].ValueDataType == "EnumRange")
                    {
                        for (int j = 0; j < constantValues.Count; ++j)
                        {
                            var constantValue = constantValues[j];
                            var member = Expression.Property(parameter, propertyName);
                            var instance = Activator.CreateInstance(member.Type);
                            var enumType = Enum.Parse(instance.GetType(), constantValue);
                            ConstantExpression constant = Expression.Constant(enumType);
                            var body = Expression.Equal(member, constant);
                            orBody = Expression.OrElse(body, orBody);
                        }
                    }
                    else if (queries[i].ValueDataType == "DateRange")
                    {
                        var fromDate = DateTime.ParseExact(constantValues[0], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        var toDate = DateTime.ParseExact(constantValues[1], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        var member = Expression.Property(parameter, propertyName);
                        ConstantExpression fromDateConstant = Expression.Constant(fromDate);
                        var fromDateBody = Expression.GreaterThanOrEqual(member, fromDateConstant);
                        ConstantExpression toDateConstant = Expression.Constant(toDate);
                        var toDateBody = Expression.LessThanOrEqual(member, toDateConstant);
                        orBody = Expression.AndAlso(fromDateBody, toDateBody);
                    }
                    finalBody = Expression.AndAlso(orBody, finalBody);
                }
            }

            var finalExpression = Expression.Lambda<Func<Declaration, bool>>(finalBody, parameter);
            return finalExpression;
        }
    }
}
