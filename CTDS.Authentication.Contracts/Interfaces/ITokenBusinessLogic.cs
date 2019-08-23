using CTDS.Authentication.Contracts.Dto;
using CTDS.Database.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CTDS.Authentication.Contracts.Interfaces
{
    public interface ITokenBusinessLogic
    {
        JwtTokenData CreateJwtTokens(User user);
        void AddNewToken(User user, string accessToken, string refreshTokenSerialNumber, string refreshToken);
        void DeleteToken(string token);
        string RefreshToken(string RefreshTokenSerialId);
    }
}
