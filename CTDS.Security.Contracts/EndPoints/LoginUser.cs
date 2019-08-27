namespace CTDS.Security.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/checkuser", "POST")]
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
