namespace CTDS.CaseManagement.Contracts.Dto
{
    using System.Collections.Generic;
    public class OpenCasesDto
    {
       public List<CaseTableDto> Cases { get; set; }
        public int TotalCount { get; set; }
    }
}
