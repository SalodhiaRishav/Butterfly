namespace CTDS.Security.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Configuration;
    using System.Collections.Specialized;

    using CTDS.Database.Models.Authentication;
    using CTDS.Security.Contracts.Dto;
    using CTDS.Security.Contracts.Interfaces;
    using CTDS.Security.Application.Repository.Interfaces;

    using Microsoft.IdentityModel.Tokens;
       
    public class TokenBusinessLogic : ITokenBusinessLogic
    {
        private readonly IRoleBusinessLogic RoleBusinessLogic;
        private readonly ITokenRepository TokenRepository;
        private readonly IUserRepository UserRepository;
        private readonly string SecretKey = ConfigurationManager.AppSettings["secret"];
        private readonly string TokenIssuerName = ConfigurationManager.AppSettings["issuerName"];
        private readonly double AccessTokenExpirationTimeInMinutes = double.Parse(ConfigurationManager.AppSettings["accessTokenExpirationTimeInMinute"]);
        private readonly double RefreshTokenExpirationTimeInMinutes = double.Parse(ConfigurationManager.AppSettings["refreshTokenExpirationTimeInMinute"]);

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
            var token = new JwtTokenData
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
                RefreshTokenSerial = refreshTokenSerial,
                Claims = claims
            };
            return token;
        }
        private (string AccessToken, IEnumerable<Claim> Claims) GenerateAccessToken(User user)
        {
            byte[] key = Convert.FromBase64String(SecretKey);
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
                Issuer = TokenIssuerName,
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(AccessTokenExpirationTimeInMinutes),
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
            byte[] key = Convert.FromBase64String(SecretKey);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            var refreshTokenSerial = this.CreateCryptographicallySecureGuid().ToString().Replace("-", "");
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.SerialNumber, refreshTokenSerial));

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = TokenIssuerName,
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(RefreshTokenExpirationTimeInMinutes),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            var refreshTokenValue = handler.WriteToken(token);
            return (refreshTokenValue, refreshTokenSerial);
        }

        public void AddNewToken(User user, string accessToken, string refreshTokenSerialNumber, string refreshToken)
        {
            DeleteExpiredTokens();
            Token userToken = new Token();
            userToken.UserId = user.Id;
            userToken.RefreshTokenValue = refreshToken;
            userToken.AccessTokenHash = accessToken;
            userToken.RefreshTokenIdHash = refreshTokenSerialNumber;
            userToken.RefreshTokenIdHashSource = null;
            userToken.RefreshTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(RefreshTokenExpirationTimeInMinutes);
            userToken.AccessTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(AccessTokenExpirationTimeInMinutes);
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

                byte[] key = Convert.FromBase64String(SecretKey);
               
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

        public string RefreshToken(string refreshTokenSerialId)
        {
            var tokenList =TokenRepository.Find(ut => ut.RefreshTokenIdHash == refreshTokenSerialId).ToList();
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
            userToken.AccessTokenExpiresDateTime = DateTimeOffset.UtcNow.AddMinutes(AccessTokenExpirationTimeInMinutes);
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
            var expiredTokenList = TokenRepository.Find(uToken => uToken.RefreshTokenExpiresDateTime <= DateTime.UtcNow);
            foreach (var token in expiredTokenList)
            {
               TokenRepository.Delete(token);
            }
        }

        public void DeleteToken(string token)
        {
            var delTokenList = TokenRepository.Find(t => t.AccessTokenHash == token);

            TokenRepository.Delete(delTokenList.First());
        }
    }
}
