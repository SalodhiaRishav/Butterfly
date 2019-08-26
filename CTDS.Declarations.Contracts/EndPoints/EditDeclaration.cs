namespace CTDS.Declarations.Contracts.EndPoints
{  
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using ServiceStack.ServiceHost;

    [Route("/updatedeclaration","POST")]
    public class EditDeclaration
    {
        public DeclarationDto Declaration { get; set; }
        public ReferenceDto[] ReferenceData { get; set; }
    }
}
