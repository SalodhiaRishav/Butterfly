namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using System;

    using ServiceStack.ServiceHost;
    

    [Route("/casemanagement/{caseId}", "GET")]
    public class GetCaseById 
    {
       public Guid CaseId { get; set; }
    }
}