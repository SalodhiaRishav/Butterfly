﻿namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/getalldeclaration","GET")]
    public class GetAllDeclaration
    {
        public int data { get; set; }
    }
}
