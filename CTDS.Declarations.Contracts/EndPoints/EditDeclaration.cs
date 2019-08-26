namespace CTDS.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using CTDS.Declarations.Contracts.DeclarationDTO;

    [Route("/updatedeclaration","POST")]
    public class EditDeclaration
    {
        public DeclarationDto Declaration { get; set; }
        public ReferenceDto[] ReferenceData { get; set; }
    }
}
