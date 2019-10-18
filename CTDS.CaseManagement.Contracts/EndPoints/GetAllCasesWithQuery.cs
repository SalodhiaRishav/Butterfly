namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System.Collections.Generic;

    using CTDS.CaseManagement.Contracts.Dto;

    [Route("/casewithquery", "POST")]
    public class GetAllCasesWithQuery
    {
        public List<QueryDto> Queries { get; set; }
        public int PageNumber { get; set; }
        public int maxRowsPerPage { get; set; }
        public string SortBy { get; set; }
        public bool SortDesc { get; set; }
    }
}
