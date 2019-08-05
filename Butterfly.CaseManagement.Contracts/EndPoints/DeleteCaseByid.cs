namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System;

    [Route("/casemanagement/{caseId}", "DELETE")]
    public class DeleteCaseById
    {
        public Guid caseId { get; set; }
    }
}
