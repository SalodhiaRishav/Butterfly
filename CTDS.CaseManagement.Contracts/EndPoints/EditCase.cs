namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using CTDS.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "PUT")]
    public class EditCase
    {
        public CaseDto CaseDto { get; set; }
    }
}
