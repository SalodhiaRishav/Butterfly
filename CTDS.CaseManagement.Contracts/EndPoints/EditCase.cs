namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    using CTDS.CaseManagement.Contracts.Dto;
  

    [Route("/casemanagement", "PUT")]
    public class EditCase
    {
        public CaseDto CaseDto { get; set; }
    }
}
