namespace CTDS.Declarations.Contracts.EndPoints
{
    using System;

    using ServiceStack.ServiceHost;
    

    [Route("/getdeclarationbyguid/{guid}","GET")]
    public class GetDeclarationByGuid
    {
        public Guid Guid { get; set; }
    }
}
