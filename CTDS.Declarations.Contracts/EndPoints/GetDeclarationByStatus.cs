namespace CTDS.Declarations.Contracts.EndPoints
{
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceHost;
    using System;

    [Route("/declarationbystatus", "POST")]
    public class GetDeclarationByStatus
    {
        public String DeclarationStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
