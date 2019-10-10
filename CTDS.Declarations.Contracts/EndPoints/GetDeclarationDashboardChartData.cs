namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System;

    [Route("/declarationchart", "POST")]
    public class GetDeclarationDashboardChartData
    {
        public String DeclarationStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
