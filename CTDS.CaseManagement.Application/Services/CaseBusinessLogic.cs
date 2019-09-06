namespace CTDS.CaseManagement.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.Database.Models.CaseManagement;
    

    public class CaseBusinessLogic : ICaseBusinessLogic
    {
        private readonly ICaseRepository CaseRepository;
        private readonly IClientBusinessLogic ClientBusinessLogic;
        private readonly ICaseInformationBusinessLogic CaseInformationBusinessLogic;
        private readonly ICaseStatusBusinessLogic CaseStatusBusinessLogic;
        private readonly INotesBusinessLogic NotesBusinessLogic;
        private readonly ICaseReferenceBusinessLogic CaseReferenceBusinessLogic;

        public CaseBusinessLogic(
            IClientBusinessLogic clientBusinessLogic,
            ICaseInformationBusinessLogic caseInformationBusinessLogic,
            ICaseStatusBusinessLogic caseStatusBusinessLogic,
            INotesBusinessLogic notesBusinessLogic,
            ICaseReferenceBusinessLogic caseReferenceBusinessLogic,
            ICaseRepository caseRepository
         )
        {
            ClientBusinessLogic = clientBusinessLogic;
            CaseInformationBusinessLogic = caseInformationBusinessLogic;
            CaseStatusBusinessLogic = caseStatusBusinessLogic;
            NotesBusinessLogic = notesBusinessLogic;
            CaseReferenceBusinessLogic = caseReferenceBusinessLogic;
            CaseRepository = caseRepository;
        }
        public CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> caseReferenceDtos)
        {
            try
            {
                CaseDto addedCaseDto = new CaseDto();
                Case newCase = new Case();
                Case addedCase = this.CaseRepository.Add(newCase);
                addedCaseDto.CaseId = addedCase.CaseId;
                addedCaseDto.Id = addedCase.Id;
                addedCaseDto.ModifiedOn = addedCase.ModifiedOn;
                addedCaseDto.CreatedOn = addedCase.CreatedOn;
                addedCaseDto.Client = ClientBusinessLogic.AddNewClient(clientDto, addedCase.Id);
                addedCaseDto.CaseInformation = CaseInformationBusinessLogic.AddNewCaseInformation(caseInformationDto, addedCase.Id);
                addedCaseDto.CaseStatus = CaseStatusBusinessLogic.AddNewCaseStatus(caseStatusDto, addedCase.Id);
                addedCaseDto.Notes = NotesBusinessLogic.AddNewNotes(notesDto, addedCase.Id);
                addedCaseDto.References = CaseReferenceBusinessLogic.AddNewCaseReferences(caseReferenceDtos, addedCase.Id);
                return addedCaseDto;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public CaseDto GetCaseById(Guid caseId)
        {
            CaseDto caseDto = new CaseDto();
            try
            {
                var caseList = this.CaseRepository.Find(c => c.Id == caseId);
                if (caseList.Count == 0)
                {
                    return null;
                }
                caseDto.CaseId = caseList.First().CaseId;
                caseDto.Id = caseList.First().Id;
                caseDto.ModifiedOn = caseList.First().ModifiedOn;
                caseDto.CreatedOn = caseList.First().CreatedOn;
                caseDto.Client = ClientBusinessLogic.GetClientByCaseId(caseId);
                caseDto.CaseInformation = CaseInformationBusinessLogic.GetCaseInformationByCaseId(caseId);
                caseDto.CaseStatus = CaseStatusBusinessLogic.GetCaseStatusByCaseId(caseId);
                caseDto.Notes = NotesBusinessLogic.GetNotesByCaseId(caseId);
                caseDto.References = CaseReferenceBusinessLogic.GetCaseReferencesByCaseId(caseId);
                return caseDto;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteCaseById(Guid caseId)
        {
            CaseDto caseDto = new CaseDto();
            try
            {
                Case caseToDelete = new Case();
                var caseList = this.CaseRepository.Find(c => c.Id == caseId);
                if (caseList.Count != 0)
                {
                    caseToDelete = caseList.First();
                }
                else
                {
                    return;
                }

                this.ClientBusinessLogic.DeleteClientByCaseId(caseId);
                this.CaseInformationBusinessLogic.DeleteCaseInformationByCaseId(caseId);
                this.CaseStatusBusinessLogic.DeleteCaseStatusByCaseId(caseId);
                this.NotesBusinessLogic.DeleteNotesByCaseId(caseId);
                this.CaseReferenceBusinessLogic.DeleteCaseReferenceByCaseId(caseId);
                this.CaseRepository.Delete(caseToDelete);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int GetCaseCount()
        {
            return CaseRepository.FindCaseCount();
        }

        public Dictionary<string,int> GetFilteredCaseCount()
        {
            return CaseRepository.FindFilteredCaseCount();
        }

        public List<CaseDto> GetAllCases()
        {
            List<CaseDto> caseDtos = new List<CaseDto>();
            try
            {
                List<Case> cases = CaseRepository.List;
                if (cases.Count == 0)
                {
                    return null;
                }

                foreach (var @case in cases)
                {
                    CaseDto caseDto = new CaseDto();
                    caseDto.CaseId = @case.CaseId;
                    caseDto.Id = @case.Id;
                    caseDto.ModifiedOn = @case.ModifiedOn;
                    caseDto.CreatedOn = @case.CreatedOn;
                    caseDto.Client = ClientBusinessLogic.GetClientByCaseId(@case.Id);
                    caseDto.CaseInformation = CaseInformationBusinessLogic.GetCaseInformationByCaseId(@case.Id);
                    caseDto.CaseStatus = CaseStatusBusinessLogic.GetCaseStatusByCaseId(@case.Id);
                    caseDto.Notes = NotesBusinessLogic.GetNotesByCaseId(@case.Id);
                    caseDto.References = CaseReferenceBusinessLogic.GetCaseReferencesByCaseId(@case.Id);
                    caseDtos.Add(caseDto);
                }
                return caseDtos;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public CaseDto EditCase(Guid caseId, ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> caseReferenceDtos)
        {
            CaseDto caseDto = new CaseDto();
            try
            {
                var caseList = this.CaseRepository.Find(c => c.Id == caseId);
                if (caseList.Count == 0)
                {
                    return null;
                }

                Case @case = caseList.First();
                @case = this.CaseRepository.Update(@case);
                caseDto.Id = @case.Id;
                caseDto.CaseId = @case.CaseId;
                caseDto.ModifiedOn = @case.ModifiedOn;
                caseDto.CreatedOn = @case.CreatedOn;

                caseDto.Client = this.ClientBusinessLogic.EditClient(clientDto);
                caseDto.CaseInformation = this.CaseInformationBusinessLogic.EditCaseInformation(caseInformationDto);
                caseDto.CaseStatus = this.CaseStatusBusinessLogic.EditCaseStatus(caseStatusDto);
                caseDto.Notes = this.NotesBusinessLogic.EditNotes(notesDto);
                caseDto.References = this.CaseReferenceBusinessLogic.EditCaseReferences(caseReferenceDtos,caseId);
                return caseDto;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
