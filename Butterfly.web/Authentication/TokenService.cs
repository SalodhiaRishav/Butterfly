namespace Butterfly.web.Authentication
{
    using Butterfly.Authentication.Contracts.EndPoints;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.web.CommonResponse;
    using Serilog;
    using ServiceStack.ServiceHost;
    using ServiceStack.ServiceInterface;
    using System;
    using System.Web;

    public class TokenService : Service
    {
        private readonly ITokenBusinessLogic _tokenBusinessLogic;

        public TokenService(ITokenBusinessLogic tokenBusinessLogic)
        {
            _tokenBusinessLogic = tokenBusinessLogic;
           
        }
        public OperationResponse<RefreshTokenResult> Post(RefreshAccessToken request)
        {
            OperationResponse<RefreshTokenResult> result = new OperationResponse<RefreshTokenResult>();
            try
            {
                

                string refreshTokenSerial = request.RefreshTokenSerialId;
                if (String.IsNullOrEmpty(refreshTokenSerial))
                {
                    Log.Error("refresh token is empty");
                    result.OnError("Invalid token, please login again", null);
                    return result;
                }

                var accessToken = _tokenBusinessLogic.RefreshToken(refreshTokenSerial);
                if (accessToken == null)
                {
                    Log.Error("Access Token is Empty");
                    result.OnError("Invalid token, please login again", null);
                    return result;
                }
                result.OnSuccess(new RefreshTokenResult() { AccessToken = accessToken },
                    "new token recieved successfully");
                return result;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                result.OnException(e.Message);
                return result;
                
            }
        }
        public string GET(LogoutUser request)
        {
            // var token = req.Headers.Get("Authorization");


           var token = HttpContext.Current.Request.Headers.Get("Authorization");
            _tokenBusinessLogic.DeleteToken(token);
            return "logged out";

        }
    }
}