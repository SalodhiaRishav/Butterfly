namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using System;

    using CTDS.CaseManagement.Contracts.Dto;
   
    public interface INotesBusinessLogic
    {
        NotesDto AddNewNotes(NotesDto notesDto, Guid caseId);
        NotesDto GetNotesByCaseId(Guid caseId);
        void DeleteNotesByCaseId(Guid caseId);
        NotesDto EditNotes(NotesDto notesDto);
    }
}
