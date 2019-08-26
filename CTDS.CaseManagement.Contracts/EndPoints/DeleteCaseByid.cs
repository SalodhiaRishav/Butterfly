namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using System;

    using ServiceStack.ServiceHost;
    

    [Route("/casemanagement/{caseId}", "DELETE")]
    public class DeleteCaseById
    {
        public Guid caseId { get; set; }
    }
}
