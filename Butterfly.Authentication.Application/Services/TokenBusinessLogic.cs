namespace Butterfly.Authentication.Application.Services
{
    using Butterfly.Database.Models.Authentication;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using Butterfly.Authentication.Contracts.Dto;
    using Butterfly.Authentication.Contracts.Interfaces;
    using Butterfly.Authentication.Application.Repository.Interfaces;

    public class TokenBusinessLogic : ITokenBusinessLogic
    {
        private static string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        private readonly IRoleBusinessLogic RoleBusinessLogic;
        private readonly ITokenRepository TokenRepository;
        private readonly IUserRepository UserRepository;
        public TokenBusinessLogic(IRoleBusinessLogic roleBusinessLogic,ITokenRepository tokenRepository,IUserRepository userRepository)
        {
            RoleBusinessLogic = roleBusinessLogic;
            TokenRepository = tokenRepository;
            UserRepository = userRepository;
        }

        public JwtTokenData CreateJwtTokens(User user)
        {
            var (accessToken, claims) = GenerateAccessToken(user);
            var (refreshTokenValue, refreshTokenSerial) = GenerateRefreshToken(user);
            return new JwtTokenData
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
                RefreshTokenSerial = refreshTokenSerial,
                Claims = claims
            };
        }

        private (string AccessToken, IEnumerable<Claim> Claims) GenerateAccessToken(User user)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            List<RoleDto> roles = RoleBusinessLogic.GetUserRoles(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName, ClaimValueTypes.String));
            }
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = "rishav server",
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            var accessToken = handler.WriteToken(token);
            return (accessToken, claims);
        }

        private Guid CreateCryptographicallySecureGuid()
        {
            RandomNumberGenerator rand = RandomNumberGenerator.Create();
            var bytes = new byte[16];
            rand.GetBytes(bytes);
            return new Guid(bytes);
        }

        private (string RefreshTokenValue, string RefreshTokenSerial) GenerateRefreshToken(User user)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var refreshTokenSerial = this.CreateCryptographicallySecureGuid().ToString().Replace("-", "");
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.SerialNumber, refreshTokenSerial));

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = "rishav server",
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            var refreshTokenValue = handler.WriteToken(token);
            return (refreshTokenValue, refreshTokenSerial);
        }

        public void AddNewToken(User user, string accessToken, string refreshTokenSerialNumber)
        {
            Token userToken = new Token();
            userToken.UserId = user.Id;
            userToken.AccessTokenHash = accessToken;
            userToken.RefreshTokenIdHash = refreshTokenSerialNumber;
            userToken.RefreshTokenIdHashSource = null;
            userToken.RefreshTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(60);
            userToken.AccessTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(2);
            TokenRepository.Add(userToken);
        }


       

        private ClaimsPrincipal GetPrincipalForRefreshingToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;

                byte[] key = Convert.FromBase64String(secret);
               
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string RefreshToken(string RefreshTokenSerialId)
        {
            var tokenList =TokenRepository.Find(ut => ut.RefreshTokenIdHash == RefreshTokenSerialId).ToList();
            if (tokenList.Count == 0)
            {
                return null;
            }

            var userToken = tokenList.First();
            if (userToken.RefreshTokenExpiresDateTime < DateTime.UtcNow)
            {
                DeleteExpiredTokens();
                return null;
            }

            User user = GetUserFromClaim(userToken.AccessTokenHash);
            if (user == null)
            {
                return null;
            }
            var accessToken = GenerateAccessToken(user).AccessToken;
            userToken.AccessTokenHash = accessToken;
            userToken.AccessTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(8);
            TokenRepository.Update(userToken);
            return userToken.AccessTokenHash;
        }

        private User GetUserFromClaim(string accessToken)
        {
            try
            {
                ClaimsPrincipal principal = GetPrincipalForRefreshingToken(accessToken);
                if (principal == null)
                    return null;
                ClaimsIdentity identity = null;
                identity = (ClaimsIdentity)principal.Identity;
                if (identity == null)
                {
                    return null;
                }
                var email = identity.FindFirst(ClaimTypes.Email).Value;
                var userList = UserRepository.Find(u => u.Email == email).ToList();
                if (userList.Count == 0)
                {
                    return null;
                }
                return userList.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void DeleteExpiredTokens()
        {
            var expiredTokenList = TokenRepository.Find(uToken => uToken.RefreshTokenExpiresDateTime <= DateTime.UtcNow).ToList();
            foreach (var token in expiredTokenList)
            {
               TokenRepository.Delete(token);
            }
        }

        private void RevokeRefereshToken(string refreshToken)
        {
            var refreshTokenList = TokenRepository.Find(uToken => uToken.RefreshTokenIdHash == refreshToken).ToList();
            if (refreshTokenList.Count != 0)
            {
                TokenRepository.Delete(refreshTokenList.First());
            }
        }
    }
}
