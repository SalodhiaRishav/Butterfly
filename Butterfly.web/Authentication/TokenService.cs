namespace Butterfly.web.Authentication
{
    using Butterfly.Authentication.Contracts.EndPoints;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.web.CommonResponse;
    using ServiceStack.ServiceInterface;
    using System;
    public class TokenService : Service
    {
        private readonly ITokenBusinessLogic TokenBusinessLogic;

        public TokenService(ITokenBusinessLogic tokenBusinessLogic)
        {
            TokenBusinessLogic = tokenBusinessLogic;
        }
        public OperationResponse<RefreshTokenResult> Post(RefreshAccessToken request)
        {
            OperationResponse<RefreshTokenResult> result = new OperationResponse<RefreshTokenResult>();
            string refreshTokenSerial = request.RefreshTokenSerialId;
            if (String.IsNullOrEmpty(refreshTokenSerial))
            {
                result.OnError("Invalid token, please login again", null);
                return result;
            }

            var accessToken = TokenBusinessLogic.RefreshToken(refreshTokenSerial);
            if (accessToken == null)
            {
                result.OnError("Invalid token, please login again", null);
                return result;
            }
            result.OnSuccess(new RefreshTokenResult() { AccessToken = accessToken },
                "new token recieved successfully");
            return result;
        }
    }
}