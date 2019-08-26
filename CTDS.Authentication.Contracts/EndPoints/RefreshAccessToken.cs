namespace CTDS.Authentication.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;

    [Route("/refreshtoken", "POST")]
    public class RefreshAccessToken
    {
        public string RefreshTokenSerialId { get; set; }
    }
}