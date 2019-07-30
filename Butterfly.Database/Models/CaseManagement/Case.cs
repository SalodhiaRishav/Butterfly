namespace Butterfly.Database.Models.CaseManagement
{
    using System.Collections.Generic;

    public class Case : BaseModel
    {
        public Client Client { get; set; }
        public CaseInformation CaseInformation { get; set; }
        public Notes Notes { get; set; }
        public CaseStatus CaseStatus { get; set; }
        public List<CaseReference> CaseReferences { get; set; }
    }
}
