namespace Butterfly.Database.Models.CaseManagement
{
    using System;

    public class Notes : BaseModel
    {
        public string NotesByCpa { get; set; }
        public Guid CaseId { get; set; }
    }
}
