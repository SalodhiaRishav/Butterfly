namespace CTDS.Common.EndPoints
{
    using System;

    using ServiceStack.ServiceHost;

    [Route("/getdropdownitems/{ListType}","GET")]
    public class GetMasterData
    {
        public String ListType { get; set; } 
    }
}
