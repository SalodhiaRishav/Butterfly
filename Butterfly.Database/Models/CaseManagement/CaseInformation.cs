namespace Butterfly.Database.Models.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Enums;
    using System;

    public class CaseInformation : BaseModel
    {
        public string Description { get; set; }
        public string MessageFromClient { get; set; }
        public PriorityType Priority { get; set; }
        public Guid CaseId { get; set; }
    }
}
