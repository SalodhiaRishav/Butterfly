namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/casemanagement/{caseStatus}", "GET")]
    public class GetCaseByStatus
    {
        public string CaseStatus { get; set; }
    }
}
