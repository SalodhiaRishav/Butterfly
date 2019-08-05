namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "GET")]
    public class GetCaseById 
    {
        public int id { get; set; }
    }
}