namespace CTDS.web.Authentication
{
    using System;
    using System.Web;

    using CTDS.Authentication.Contracts.EndPoints;
    using CTDS.Authentication.Contracts.Interfaces;
    using CTDS.web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;
    
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
                    "new token received successfully");
                return result;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                result.OnException(e.Message);
                return result;
                
            }
        }
        public OperationResponse<bool> Get(LogoutUser request)
        {
            OperationResponse<bool> result = new OperationResponse<bool>();
            var token = HttpContext.Current.Request.Headers.Get("Authorization");
            _tokenBusinessLogic.DeleteToken(token);
            result.OnSuccess(true, "logged out");
            return result;

        }
    }
}