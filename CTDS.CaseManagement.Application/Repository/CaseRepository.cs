namespace CTDS.CaseManagement.Application.Repository
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.Database.Context;
    using CTDS.Database.Models.CaseManagement;

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

                Dictionary<string, int> filteredList = new Dictionary<string, int>();
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

    }
}