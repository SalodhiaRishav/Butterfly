namespace CTDS.CaseManagement.Application.Repository.Interfaces
{
    using System.Collections.Generic;

    using CTDS.Database.Models.CaseManagement;
    public interface ICaseRepository:IRepository<Case>
    {
        int FindCaseCount();
        int FindCasesInLastSevenDays();
        Dictionary<string,int> FindFilteredCaseCount();
        
    }
}