namespace CTDS.Database.Models.CaseManagement
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;
  

    public class CaseStatus:BaseModel
    {
        public CaseStatusType Status { get; set; }
        public Guid CaseId { get; set; }
    }
}
