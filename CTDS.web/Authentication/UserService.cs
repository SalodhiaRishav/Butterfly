namespace CTDS.web.Authentication
{
    using System;

    using CTDS.Authentication.Contracts.EndPoints;
    using CTDS.web.CommonResponse;
    using CTDS.Authentication.Contracts.Interfaces;
    using CTDS.Authentication.Contracts.Dto;
   
    using Serilog;
    using ServiceStack.ServiceInterface;

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
                    Log.Error("Wrong Username ");
                    result.OnError("Wrong username or password", null);
                    return result;
                }
                result.OnSuccess(loginResultDto, "Logined successfully");
                return result;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + "\n" + e.StackTrace);
                result.OnException("server error while login");
                return result;
            }
           
        }
       
    }
}