namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using System;

    using CTDS.CaseManagement.Contracts.Dto;
   
    public interface ICaseInformationBusinessLogic
    {
        CaseInformationDto AddNewCaseInformation(CaseInformationDto caseInformationDto, Guid caseId);
        CaseInformationDto GetCaseInformationByCaseId(Guid caseId);
        void DeleteCaseInformationByCaseId(Guid caseId);
        CaseInformationDto EditCaseInformation(CaseInformationDto caseInformationDto);
    }
}
