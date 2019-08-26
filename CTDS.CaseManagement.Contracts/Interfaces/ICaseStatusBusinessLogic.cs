namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using System;

    using CTDS.CaseManagement.Contracts.Dto;   

    public interface ICaseStatusBusinessLogic
    {
        CaseStatusDto AddNewCaseStatus(CaseStatusDto caseStatusDto, Guid caseId);
        CaseStatusDto GetCaseStatusByCaseId(Guid caseId);
        void DeleteCaseStatusByCaseId(Guid caseId);
        CaseStatusDto EditCaseStatus(CaseStatusDto caseStatusDto);
    }
}
