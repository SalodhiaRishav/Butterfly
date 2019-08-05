namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "POST")]
    public class CreateCase 
    {
        public CaseDto CaseDto{ get; set; }
    }
}
