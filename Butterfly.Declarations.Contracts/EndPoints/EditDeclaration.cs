namespace Butterfly.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using Butterfly.Declarations.Contracts.DeclarationDTO;

    [Route("/updatedeclaration","POST")]
    public class EditDeclaration
    {
        public DeclarationDto declaration { get; set; }
        public ReferenceDto[] referenceData { get; set; }
    }
}
