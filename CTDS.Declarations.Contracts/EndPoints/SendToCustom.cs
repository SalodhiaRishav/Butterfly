namespace CTDS.Declarations.Contracts.EndPoints
{
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using ServiceStack.ServiceHost;

    [Route("/sendtocustom","POST")]
    public class SendToCustom
    {
        public DeclarationDto Declaration { get; set; }
    }
}
