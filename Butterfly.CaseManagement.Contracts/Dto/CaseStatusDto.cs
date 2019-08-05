namespace Butterfly.CaseManagement.Contracts.Dto
{
    using Butterfly.CaseManagement.Contracts.Enums;
    using System;

    public class CaseStatusDto : BaseDto
    {
        public CaseStatusType Status { get; set; }
        public Guid CaseId { get; set; }
    }
}
