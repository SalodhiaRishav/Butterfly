namespace Butterfly.Declarations.Contracts.EndPoints
{
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceHost;

    [Route("/addnewdropdown","POST")]
    public class AddDropDownItem :IReturn<bool>
    {
        public DropDownDto AddItem { get; set; } 
    }
}
