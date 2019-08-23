namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using CTDS.CaseManagement.Contracts.Dto;
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "POST")]
    public class CreateCase 
    {
        public CaseDto CaseDto{ get; set; }
    }
}
