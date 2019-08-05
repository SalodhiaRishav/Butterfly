namespace Butterfly.CaseManagement.Application.Services
{
    using Butterfly.CaseManagement.Application.Repository.Interfaces;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.Database.Models.CaseManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CaseBusinessLogic : ICaseBusinessLogic
    {
        #region Repository
        private readonly IClientRepository ClientRepository;
        private readonly ICaseInformationRepository CaseInformationRepository;
        private readonly ICaseStatusRepository CaseStatusRepository;
        private readonly ICaseReferenceRepository CaseReferenceRepository;
        private readonly INotesRepository NotesRepository;
        private readonly ICaseRepository CaseRepository;
        #endregion
        #region Mapper
        private readonly IClientMapper ClientMapper;
        private readonly ICaseStatusMapper CaseStatusMapper;
        private readonly ICaseReferenceMapper CaseReferenceMapper;
        private readonly INotesMapper NotesMapper;
        private readonly ICaseInformationMapper CaseInformationMapper;
        #endregion


        public CaseBusinessLogic(
            ICaseRepository caseRepository,
            IClientRepository clientRepository,
            ICaseInformationRepository caseInformationRepository,
            ICaseStatusRepository caseStatusRepository,
            ICaseReferenceRepository caseReferenceRepository,
            INotesRepository notesRepository,
            ICaseInformationMapper caseInformationMapper,
            ICaseStatusMapper caseStatusMapper,
            IClientMapper clientMapper,
            INotesMapper notesMapper,
            ICaseReferenceMapper caseReferenceMapper)
        {
            ClientRepository = clientRepository;
            CaseInformationRepository = caseInformationRepository;
            CaseReferenceRepository = caseReferenceRepository;
            CaseStatusRepository = caseStatusRepository;
            NotesRepository = notesRepository;
            CaseRepository = caseRepository;
            CaseInformationMapper = caseInformationMapper;
            ClientMapper = clientMapper;
            CaseStatusMapper = caseStatusMapper;
            NotesMapper = notesMapper;
            CaseReferenceMapper = caseReferenceMapper;


        }
        public CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> caseReferenceDtos)
        {
            Case newCase = new Case();
            Case addedCase;
            Client client;
            CaseInformation caseInformation;
            CaseStatus caseStatus;
            List<CaseReference> caseReferences;
            List<CaseReference> addedCaseReferences = new List<CaseReference>();
            Notes notes;
            try
            {
                addedCase=this.CaseRepository.Add(newCase);
                client=ClientMapper.DtoToModel(clientDto);
                client.CaseId = addedCase.Id;
                client=this.ClientRepository.Add(client);

                caseInformation = CaseInformationMapper.DtoToModel(caseInformationDto);
                caseInformation.CaseId = addedCase.Id;
                caseInformation = this.CaseInformationRepository.Add(caseInformation);

                caseStatus = CaseStatusMapper.DtoToModel(caseStatusDto);
                caseStatus.CaseId = addedCase.Id;
                caseStatus = this.CaseStatusRepository.Add(caseStatus);

                notes = NotesMapper.DtoToModel(notesDto);
                notes.CaseId = addedCase.Id;
                notes = this.NotesRepository.Add(notes);

                caseReferences = CaseReferenceMapper.DtoListToModelList(caseReferenceDtos);
                foreach(var caseReference in caseReferences)
                {
                    caseReference.CaseId = addedCase.Id;
                    CaseReference addedCaseReference=CaseReferenceRepository.Add(caseReference);
                    addedCaseReferences.Add(addedCaseReference);
                }

                CaseDto addedCaseDto = new CaseDto()
                {
                    Id=addedCase.Id,
                    Client = ClientMapper.ModelToDto(client),
                    CaseStatus=CaseStatusMapper.ModelToDto(caseStatus),
                    CaseInformation=CaseInformationMapper.ModelToDto(caseInformation),
                    Notes=NotesMapper.ModelToDto(notes),
                    References=CaseReferenceMapper.ModelListToDtoList(addedCaseReferences),
                    CreatedOn=addedCase.CreatedOn,
                    ModifiedOn=addedCase.ModifiedOn
                };
                return addedCaseDto;

            }
            catch(Exception exception)
            {
                throw exception;
            }
            
        }

        public CaseDto GetCaseById(Guid caseId)
        {
            CaseDto caseDto = new CaseDto();
            Client client;
            CaseInformation caseInformation;
            CaseStatus caseStatus;
            List<CaseReference> caseReferences;
            Notes notes;
            try
            {
                var caseList = this.CaseRepository.Find(c => c.Id == caseId);
                if (caseList.Count != 0)
                {
                    caseDto.Id = caseList.First().Id;
                    caseDto.ModifiedOn = caseList.First().ModifiedOn;
                    caseDto.CreatedOn = caseList.First().CreatedOn;
                }
                else
                {
                    return null;
                }

                var clientList = this.ClientRepository.Find(c => c.CaseId == caseId);
                if (clientList.Count != 0)
                {
                    client = clientList.First();
                    caseDto.Client = this.ClientMapper.ModelToDto(client);
                }
                else
                {
                    caseDto.Client = null;
                }

                var caseInformationList = this.CaseInformationRepository.Find(c => c.CaseId == caseId);
                if (caseInformationList.Count != 0)
                {
                    caseInformation = caseInformationList.First();
                    caseDto.CaseInformation = this.CaseInformationMapper.ModelToDto(caseInformation);
                }
                else
                {
                    caseDto.CaseInformation = null;
                }

                var caseStatusList = this.CaseStatusRepository.Find(c => c.CaseId == caseId);
                if (caseStatusList.Count != 0)
                {
                    caseStatus = caseStatusList.First();
                    caseDto.CaseStatus = this.CaseStatusMapper.ModelToDto(caseStatus);
                }
                else
                {
                    caseDto.CaseStatus = null;
                }

                var noteList = this.NotesRepository.Find(c => c.CaseId == caseId);
                if (noteList.Count != 0)
                {
                    notes = noteList.First();
                    caseDto.Notes = this.NotesMapper.ModelToDto(notes);
                }
                else
                {
                    caseDto.Notes = null;
                }

                caseReferences = this.CaseReferenceRepository.Find(c => c.CaseId == caseId);

                if (caseReferences.Count != 0)
                {
                    caseDto.References = this.CaseReferenceMapper.ModelListToDtoList(caseReferences);
                }
                else
                {
                    caseDto.References = null;
                }
                return caseDto;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteCaseById(Guid caseId)
        {
            CaseDto caseDto = new CaseDto();
            Case caseToDelete;
            Client client;
            CaseInformation caseInformation;
            CaseStatus caseStatus;
            List<CaseReference> caseReferences;
            Notes notes;
            try
            {
                var caseList = this.CaseRepository.Find(c => c.Id == caseId);
                if (caseList.Count != 0)
                {
                    caseToDelete = caseList.First();
                }
                else
                {
                    return;
                }

                var clientList = this.ClientRepository.Find(c => c.CaseId == caseId);
                if (clientList.Count != 0)
                {
                    client = clientList.First();
                    this.ClientRepository.Delete(client);
                }
               

                var caseInformationList = this.CaseInformationRepository.Find(c => c.CaseId == caseId);
                if (caseInformationList.Count != 0)
                {
                    caseInformation = caseInformationList.First();
                    this.CaseInformationRepository.Delete(caseInformation);
                }

                var caseStatusList = this.CaseStatusRepository.Find(c => c.CaseId == caseId);
                if (caseStatusList.Count != 0)
                {
                    caseStatus = caseStatusList.First();
                    this.CaseStatusRepository.Delete(caseStatus);
                }

                var noteList = this.NotesRepository.Find(c => c.CaseId == caseId);
                if (noteList.Count != 0)
                {
                    notes = noteList.First();
                    this.NotesRepository.Delete(notes);
                }

                caseReferences = this.CaseReferenceRepository.Find(c => c.CaseId == caseId);

                if (caseReferences.Count != 0)
                {
                    this.CaseReferenceRepository.DeleteRange(caseReferences);
                }

                this.CaseRepository.Delete(caseToDelete);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
