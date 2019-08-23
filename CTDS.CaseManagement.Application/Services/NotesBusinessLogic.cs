namespace CTDS.CaseManagement.Application.Services
{
    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.Database.Models.CaseManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class NotesBusinessLogic : INotesBusinessLogic
    {
        private readonly INotesRepository NotesRepository;
        private readonly INotesMapper NotesMapper;
        public NotesBusinessLogic(INotesRepository notesRepository, INotesMapper notesMapper)
        {
            NotesRepository = notesRepository;
            NotesMapper = notesMapper;
        }
        public NotesDto AddNewNotes(NotesDto notesDto, Guid caseId)
        {
            try
            {
                if (notesDto == null)
                {
                    return null;
                }
                Notes notes = NotesMapper.DtoToModel(notesDto);
                notes.CaseId = caseId;
                notes = this.NotesRepository.Add(notes);
                return this.NotesMapper.ModelToDto(notes);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public NotesDto GetNotesByCaseId(Guid caseId)
        {
            try
            {
                List<Notes> notesList = this.NotesRepository.Find(c => c.CaseId == caseId);
                if (notesList.Count != 0)
                {
                    Notes notes = notesList.First();
                    return this.NotesMapper.ModelToDto(notes);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteNotesByCaseId(Guid caseId)
        {
            try
            {
                List<Notes> notesList = this.NotesRepository.Find(c => c.CaseId == caseId);
                if (notesList.Count != 0)
                {
                    Notes notes = notesList.First();
                    this.NotesRepository.Delete(notes);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public NotesDto EditNotes(NotesDto notesDto)
        {
            try
            {
                if (notesDto == null)
                {
                    return null;
                }
                Notes notes = this.NotesMapper.DtoToModel(notesDto);
                notes = this.NotesRepository.Update(notes);
                return this.NotesMapper.ModelToDto(notes);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
