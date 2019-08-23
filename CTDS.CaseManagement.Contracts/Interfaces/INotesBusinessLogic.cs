namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using CTDS.CaseManagement.Contracts.Dto;
    using System;

    public interface INotesBusinessLogic
    {
        NotesDto AddNewNotes(NotesDto notesDto, Guid caseId);
        NotesDto GetNotesByCaseId(Guid caseId);
        void DeleteNotesByCaseId(Guid caseId);
        NotesDto EditNotes(NotesDto notesDto);
    }
}
