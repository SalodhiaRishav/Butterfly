namespace CTDS.CaseManagement.Contracts.EndPoints
{
    using CTDS.CaseManagement.Contracts.Enums;
    using ServiceStack.ServiceHost;
    using System;

    [Route("/casechart", "POST")]
    public class GetCaseChartData
    {
        public CaseStatusType? CaseStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
