namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    public class NotesDto : BaseDto
    {
        public string NotesByCpa { get; set; }
        public Guid CaseId { get; set; }
    }
}
