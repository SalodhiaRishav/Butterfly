namespace CTDS.Declarations.Contracts.EndPoints
{
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceHost;

    [Route("/addnewdropdown","POST")]
    public class AddDropDownItem :IReturn<bool>
    {
        public DropDownDto AddItem { get; set; } 
    }
}
