namespace Butterfly.Database.Models.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Enums;
    public class CaseStatus:BaseModel
    {
        public CaseStatusType Status { get; set; }
        public Case Case { get; set; }
    }
}
