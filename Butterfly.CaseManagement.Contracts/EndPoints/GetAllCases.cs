namespace Butterfly.CaseManagement.Contracts.EndPoints
{
    using Butterfly.CaseManagement.Contracts.Filters;
    using ServiceStack.ServiceHost;

    [AdminAuthenticationFilter]
    [Route("/casemanagement", "GET")]
    public class GetAllCases
    {
    }
}