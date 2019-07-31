namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Utils;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "POST")]
    public class CreateCase : IReturn<OperationResult<CaseDto>>
    {
        public CaseDto CaseDTO { get; set; }
    }
}
