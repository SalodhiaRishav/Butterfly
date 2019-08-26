namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using System;

    [Route("/getdeclarationbyguid/{guid}","GET")]
    public class GetDeclarationByGuid
    {
        public Guid Guid { get; set; }
    }
}
