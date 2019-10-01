namespace CTDS.CaseManagement.Application.Repository.Interfaces
{
    using System.Collections.Generic;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.Database.Models.CaseManagement;
    public interface ICaseRepository:IRepository<Case>
    {
        int FindCaseCount();
        int FindCasesInLastSevenDays();

        List<Case> GetAllFilteredCases(int index, string sort);
        Dictionary<string,int> FindFilteredCaseCount();
        List<int> FindCasesPerDayLastWeek();

        OpenCasesDto GetAllCasesWithQuery(List<QueryDto> queries, int pageNumber, int maxRowsPerPage);


    }
}