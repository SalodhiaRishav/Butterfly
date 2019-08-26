namespace CTDS.Declarations.Contracts.EndPoints
{
    using System;

    using ServiceStack.ServiceHost;
    [Route("/getdropdownitems/{ListType}","GET")]
    public class GetDropDownItems
    {
        public String ListType { get; set; } 
    }
}
