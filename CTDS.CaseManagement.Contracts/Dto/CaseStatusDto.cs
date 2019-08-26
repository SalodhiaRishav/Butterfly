namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;
   
    public class CaseStatusDto : BaseDto
    {
        public CaseStatusType Status { get; set; }
        public Guid CaseId { get; set; }
    }
}
