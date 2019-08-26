namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;


    public class CaseReferenceDto : BaseDto
    {
        public CaseReferenceType Type { get; set; }
        public string Identity { get; set; }
        public string Comment { get; set; }
        public Guid CaseId { get; set; }
    }
}
