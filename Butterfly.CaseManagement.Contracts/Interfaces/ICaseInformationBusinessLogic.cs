namespace Butterfly.CaseManagement.Contracts.Interfaces
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using System;

    public interface ICaseInformationBusinessLogic
    {
        CaseInformationDto AddNewCaseInformation(CaseInformationDto caseInformationDto, Guid caseId);
        CaseInformationDto GetCaseInformationByCaseId(Guid caseId);
        void DeleteCaseInformationByCaseId(Guid caseId);
        CaseInformationDto EditCaseInformation(CaseInformationDto caseInformationDto);
    }
}
