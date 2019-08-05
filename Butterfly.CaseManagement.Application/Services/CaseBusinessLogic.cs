namespace Butterfly.CaseManagement.Application.Services
{
    using Butterfly.CaseManagement.Application.Repository.Interfaces;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.Database.Models.CaseManagement;
    using System;
    using System.Collections.Generic;

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
    }
}
