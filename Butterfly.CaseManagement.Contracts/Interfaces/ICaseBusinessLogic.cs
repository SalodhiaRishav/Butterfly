namespace Butterfly.CaseManagement.Contracts.Interfaces
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using System;
    using System.Collections.Generic;

    public interface ICaseBusinessLogic
    {
        CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> referencesDto);
        CaseDto GetCaseById(Guid caseId);
        void DeleteCaseById(Guid caseId);
        List<CaseDto> GetAllCases();
    }
}
