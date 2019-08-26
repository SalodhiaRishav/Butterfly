namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;
    
    public class CaseInformationDto : BaseDto
    {
        public string Description { get; set; }
        public string MessageFromClient { get; set; }
        public PriorityType Priority { get; set; }
        public Guid CaseId { get; set; }
    }
}
