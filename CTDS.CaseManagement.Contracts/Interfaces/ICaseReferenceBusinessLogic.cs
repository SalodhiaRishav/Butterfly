﻿namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using CTDS.CaseManagement.Contracts.Dto;
    using System;
    using System.Collections.Generic;

    public interface ICaseReferenceBusinessLogic
    {
        List<CaseReferenceDto> AddNewCaseReferences(List<CaseReferenceDto> caseReferenceDtos, Guid caseId);
        List<CaseReferenceDto> GetCaseReferencesByCaseId(Guid caseId);
        void DeleteCaseReferenceByCaseId(Guid caseId);
        List<CaseReferenceDto> EditCaseReferences(List<CaseReferenceDto> caseReferenceDto,Guid caseId);
    }
}