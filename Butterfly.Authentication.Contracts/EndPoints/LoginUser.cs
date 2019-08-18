namespace Butterfly.Authentication.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/login", "POST")]
    public class LoginUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
