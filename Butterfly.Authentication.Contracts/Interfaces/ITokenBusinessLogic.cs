using Butterfly.Authentication.Contracts.Dto;
using Butterfly.Database.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Authentication.Contracts.Interfaces
{
    public interface ITokenBusinessLogic
    {
        JwtTokenData CreateJwtTokens(User user);
        void AddNewToken(User user, string accessToken, string refreshTokenSerialNumber);
        string RefreshToken(string RefreshTokenSerialId);
    }
}
