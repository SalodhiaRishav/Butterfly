namespace CTDS.Declarations.Contracts.EndPoints
{  
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using ServiceStack.ServiceHost;

    [Route("/updatedeclaration","POST")]
    public class EditDeclaration
    {
        public DeclarationDto declaration { get; set; }
        public ReferenceDto[] referenceData { get; set; }
    }
}
