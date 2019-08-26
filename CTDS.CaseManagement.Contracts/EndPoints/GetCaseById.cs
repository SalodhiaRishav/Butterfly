namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System;

    [Route("/casemanagement/{caseId}", "GET")]
    public class GetCaseById 
    {
       public Guid CaseId { get; set; }
    }
}