﻿namespace Butterfly.Declarations.Contracts.EndPoints
{
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceHost;

    [Route("/newdeclaration","POST")]
    public class AddDeclaration
    {
        public DeclarationDto NewDeclaration { get; set; } 
    }
}