namespace Butterfly.CaseManagement.Application.Services
{
    using System.Collections.Generic;
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Interfaces;

    public class CaseBusinessLogic : ICaseBusinessLogic
    {
        IClientRepository ClientRepository;
        public CaseBusinessLogic(IClientRepository clientRepository)
        {
            ClientRepository=clientRepository;
        }
        public CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> referencesDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
