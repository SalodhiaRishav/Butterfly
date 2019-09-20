namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using System;
    using System.Collections.Generic;

    using CTDS.CaseManagement.Contracts.Dto;
    

    public interface ICaseBusinessLogic
    {
        CaseDto AddNewCase(ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> referencesDto);
        CaseDto GetCaseById(Guid caseId);
        void DeleteCaseById(Guid caseId);
        //List<CaseDto> GetAllCases();
        List<CaseDto> GetAllCases(int index, string orderBy);

        CaseDto EditCase(Guid caseId, ClientDto clientDto, CaseInformationDto caseInformationDto, NotesDto notesDto, CaseStatusDto caseStatusDto, List<CaseReferenceDto> caseReferenceDtos);
        int GetCaseCount();
        GroupByCaseDTO GetFilteredCaseCount();
        int GetCountOfSevenDays();
        List<int> GetCasesPerDayLastWeek();
    }
}
