namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Utils;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "GET")]
    public class GetCaseById : IReturn<OperationResult<CaseDto>>
    {
        public int id { get; set; }
    }
}