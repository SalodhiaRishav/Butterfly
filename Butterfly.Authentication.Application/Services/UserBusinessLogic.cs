namespace Butterfly.Authentication.Application.Services
{
    using Butterfly.Authentication.Application.Repository.Interfaces;
    using Butterfly.Authentication.Contracts.Dto;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.Database.Models.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                TokenBusinessLogic.AddNewToken(user, jwtTokensData.AccessToken, jwtTokensData.RefreshTokenSerial);
                loginResultDto.AccessToken = jwtTokensData.AccessToken;
                loginResultDto.RefreshTokenSerial = jwtTokensData.RefreshTokenSerial;
                return loginResultDto;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
