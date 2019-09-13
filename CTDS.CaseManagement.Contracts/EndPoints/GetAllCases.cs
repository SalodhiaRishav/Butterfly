namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/casemanagement", "GET")]
    public class GetAllCases
    {
        public int index { get; set; }
        public string orderBy { get; set; }
    }
}