namespace Butterfly.CaseManagement.Contracts.Dto
{
    using Butterfly.CaseManagement.Contracts.Enums;
    using System;

    public class CaseInformationDto : BaseDto
    {
        public string Description { get; set; }
        public string MessageFromClient { get; set; }
        public PriorityType Priority { get; set; }
        public Guid CaseId { get; set; }
    }
}
