namespace CTDS.CaseManagement.Application.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.Enums;
    using CTDS.Database.Models.CaseManagement;
    public interface ICaseRepository:IRepository<Case>
    {
        List<CaseTableDto> GetAllCasesByStatus(CaseStatusType status, DateTime startDate, DateTime endDate);
        int FindCaseCount();
        int FindCasesInLastSevenDays();

        List<Case> GetAllFilteredCases(int index, string sort);
        Dictionary<string,int> FindFilteredCaseCount();
        List<int> FindCasesPerDayLastWeek();

        OpenCasesDto GetAllCasesWithQuery(List<QueryDto> queries, int pageNumber, int maxRowsPerPage);


    }
}