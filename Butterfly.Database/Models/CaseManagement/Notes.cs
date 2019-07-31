using System;

namespace Butterfly.Database.Models.CaseManagement
{
    public class Notes : BaseModel
    {
        public string NotesByCpa { get; set; }
        public Guid CaseId { get; set; }
    }
}
