namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "PUT")]
    public class EditCase
    {
        public CaseDto CaseDto { get; set; }
    }
}
