namespace CTDS.Authentication.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.Authentication.Application.Repository.Interfaces;
    using CTDS.Authentication.Contracts.Dto;
    using CTDS.Authentication.Contracts.EndPoints;
    using CTDS.Authentication.Contracts.Interfaces;
    using CTDS.Database.Models.Authentication;

    using ServiceStack.ServiceHost;
    
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserRepository UserRepository;
        private readonly ITokenBusinessLogic TokenBusinessLogic;

        public UserBusinessLogic(IUserRepository userRepository,ITokenBusinessLogic tokenBusinessLogic )
        {
            UserRepository = userRepository;
            TokenBusinessLogic = tokenBusinessLogic;
        }

        public LoginResultDto LoginUser(string email,string password)
        {
            LoginResultDto loginResultDto = new LoginResultDto();
            List<User> userList = UserRepository.Find(u => u.Email == email && u.Password == password);

            if (userList.Count == 0)
            {
                return null;
            }

            User user = userList.First();
            try
            {
                JwtTokenData jwtTokensData = TokenBusinessLogic.CreateJwtTokens(user);
                TokenBusinessLogic.AddNewToken(user, jwtTokensData.AccessToken, jwtTokensData.RefreshTokenSerial, jwtTokensData.RefreshToken);
                loginResultDto.AccessToken = jwtTokensData.AccessToken;
                loginResultDto.RefreshTokenSerial = jwtTokensData.RefreshTokenSerial;
                return loginResultDto;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public string Get(LogoutUser request, IHttpRequest req)
        {
            var token = req.Headers.Get("Authorization");
            TokenBusinessLogic.DeleteToken(token);
            return "logged out";

        }
    }
}
