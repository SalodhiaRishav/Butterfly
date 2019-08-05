namespace Butterfly.CaseManagement.Application.Services
{
    using System.Collections.Generic;
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Application.Interfaces;
    using Butterfly.CaseManagement.Contracts.Interfaces;

    public class CaseBusinessLogic : ICaseBusinessLogic
    {
       private readonly IClientRepository ClientRepository;
        private readonly ICaseInformationRepository CaseInformationRepository;
        private readonly ICaseStatusRepository CaseStatusRepository;
        private readonly ICaseReferenceRepository CaseReferenceRepository;
        private readonly INotesRepository NotesRepository;
        private readonly ICaseRepository CaseRepository;

        public CaseBusinessLogic(ICaseRepository caseRepository,IClientRepository clientRepository,ICaseInformationRepository caseInformationRepository,ICaseStatusRepository caseStatusRepository,ICaseReferenceRepository caseReferenceRepository,INotesRepository notesRepository)
        {
            ClientRepository=clientRepository;
            CaseInformationRepository = caseInformationRepository;
            CaseReferenceRepository = caseReferenceRepository;
            CaseStatusRepository = caseStatusRepository;
            NotesRepository = notesRepository;
            CaseRepository = caseRepository;
        }
        public CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> referencesDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
