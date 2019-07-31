namespace Butterfly.Database.Models.CaseManagement
{
    using System.Collections.Generic;

    public class Case : BaseModel
    {
        public List<CaseReference> CaseReferences { get; set; }
    }
}
