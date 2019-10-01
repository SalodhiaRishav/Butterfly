namespace CTDS.CaseManagement.Contracts.Dto
{
    using System.Collections.Generic;

    public class QueryDto
    {
        public string Property { get; set; }
        public List<string> Values { get; set; }
        public string ValueDataType { get; set; }
    }
}