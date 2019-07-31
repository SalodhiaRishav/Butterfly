namespace Butterfly.Database.Models.CaseManagement
{
    public class Notes : BaseModel
    {
        public string NotesByCpa { get; set; }
        public int CaseId { get; set; }
    }
}
