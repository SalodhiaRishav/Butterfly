namespace CTDS.Authentication.Contracts.Dto
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public class JwtTokenData
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenSerial { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
