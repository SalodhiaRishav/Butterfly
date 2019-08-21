namespace Butterfly.web.Authentication
{
    using ServiceStack.ServiceInterface;
    using Butterfly.Authentication.Contracts.EndPoints;
    using Butterfly.web.CommonResponse;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.Authentication.Contracts.Dto;
    using System;

    public class UserService : Service
    {
        private readonly IUserBusinessLogic UserBusinessLogic;

        public UserService(IUserBusinessLogic userBusinessLogic)
        {
            UserBusinessLogic = userBusinessLogic;
        }

        public OperationResponse<LoginResultDto> Post(LoginUser request)
        {
            OperationResponse<LoginResultDto> result = new OperationResponse<LoginResultDto>();
            try
            {
                LoginResultDto loginResultDto = UserBusinessLogic.LoginUser(request.Email, request.Password);
                if (loginResultDto == null)
                {
                    result.OnError("Wrong username or password", null);
                    return result;
                }
                result.OnSuccess(loginResultDto, "Logined successfully");
                return result;
            }
            catch(Exception)
            {
                result.OnException("server error while login");
                return result;
            }
           
        }
       
    }
}