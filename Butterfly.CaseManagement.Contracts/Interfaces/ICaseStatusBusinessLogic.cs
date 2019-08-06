namespace Butterfly.CaseManagement.Contracts.Interfaces
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using System;

    public interface ICaseStatusBusinessLogic
    {
        CaseStatusDto AddNewCaseStatus(CaseStatusDto caseStatusDto, Guid caseId);
        CaseStatusDto GetCaseStatusByCaseId(Guid caseId);
        void DeleteCaseStatusByCaseId(Guid caseId);
        CaseStatusDto EditCaseStatus(CaseStatusDto caseStatusDto);
    }
}
