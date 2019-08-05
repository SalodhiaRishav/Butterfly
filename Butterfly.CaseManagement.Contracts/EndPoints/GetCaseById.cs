namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;
    using System;

    [Route("/casemanagement/{caseId}", "GET")]
    public class GetCaseById 
    {
       public Guid caseId { get; set; }
    }
}