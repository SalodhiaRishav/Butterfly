﻿namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System;

    [Route("/casemanagement/{caseId}", "DELETE")]
    public class DeleteCaseById
    {
        public Guid CaseId { get; set; }
    }
}
