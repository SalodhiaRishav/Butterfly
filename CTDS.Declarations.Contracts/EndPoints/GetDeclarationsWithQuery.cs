namespace CTDS.Declarations.Contracts.EndPoints
{
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceHost;
    using System.Collections.Generic;

    [Route("/declarationswithquery", "POST")]
    public class GetDeclarationsWithQuery
    {
        public List<QueryDto> Queries { get; set; }
        public int PageNumber { get; set; }
        public int MaxRowsPerPage { get; set; }
        public string SortBy { get; set; }
        public bool SortDesc { get; set; } 
    }
}
