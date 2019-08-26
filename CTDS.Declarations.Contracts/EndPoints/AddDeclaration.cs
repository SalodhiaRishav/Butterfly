namespace CTDS.Declarations.Contracts.EndPoints
{
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using ServiceStack.ServiceHost;

    [Route("/newdeclaration","POST")]
    public class AddDeclaration
    {
        public DeclarationDto Declaration { get; set; } 
        public ReferenceDto[] ReferenceData { get; set; }
    }
}
