namespace Butterfly.Database.Models.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Enums;
    using System;

    public class CaseStatus:BaseModel
    {
        public CaseStatusType Status { get; set; }
        public Guid CaseId { get; set; }
    }
}
