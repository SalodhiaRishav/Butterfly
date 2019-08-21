namespace Butterfly.Authentication.Application.Services
{
    using Butterfly.Authentication.Application.Repository.Interfaces;
    using Butterfly.Authentication.Contracts.Dto;
    using Butterfly.Authentication.Contracts.EndPoints;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.Database.Models.Authentication;
    using ServiceStack.ServiceHost;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenBusinessLogic _tokenBusinessLogic;

        public UserBusinessLogic(IUserRepository userRepository,ITokenBusinessLogic tokenBusinessLogic )
        {
            _userRepository = userRepository;
            _tokenBusinessLogic = tokenBusinessLogic;
        }

        public LoginResultDto LoginUser(string email,string password)
        {
            LoginResultDto loginResultDto = new LoginResultDto();
            List<User> userList = _userRepository.Find(u => u.Email == email && u.Password == password);

            if (userList.Count == 0)
            {
                return null;
            }

            User user = userList.First();
            try
            {
                JwtTokenData jwtTokensData = _tokenBusinessLogic.CreateJwtTokens(user);
                _tokenBusinessLogic.AddNewToken(user, jwtTokensData.AccessToken, jwtTokensData.RefreshTokenSerial, jwtTokensData.RefreshToken);
                loginResultDto.AccessToken = jwtTokensData.AccessToken;
                loginResultDto.RefreshTokenSerial = jwtTokensData.RefreshTokenSerial;
                return loginResultDto;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public string GET(LogoutUser request, IHttpRequest req)
        {
            var token = req.Headers.Get("Authorization");
            _tokenBusinessLogic.DeleteToken(token);
            return "logged out";

        }
    }
}
