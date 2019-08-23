namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using CTDS.Declarations.Contracts.DeclarationDTO;

    [Route("/updatedeclaration","POST")]
    public class EditDeclaration
    {
        public DeclarationDto declaration { get; set; }
        public ReferenceDto[] referenceData { get; set; }
    }
}
