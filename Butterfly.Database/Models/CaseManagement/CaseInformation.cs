namespace Butterfly.Database.Models.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Enums;

    public class CaseInformation : BaseModel
    {
        public string Desription { get; set; }
        public string MessageFromClient { get; set; }
        public PriorityType Priority { get; set; }
        public Case Case { get; set; }
    }
}
