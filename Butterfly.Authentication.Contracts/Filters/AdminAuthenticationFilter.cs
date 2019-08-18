using Microsoft.IdentityModel.Tokens;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Butterfly.Authentication.Contracts.Filters
{
    public class AdminAuthenticationFilter : RequestFilterAttribute
    {
        private static string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            string bearerToken = req.Headers.Get("Authorization");

            if (String.IsNullOrEmpty(bearerToken))
            {
                res.ReturnAuthRequired("You are not authorized");
                res.Close();
                return;
            }

            var token = bearerToken.Split(' ')[1];
            bool isAdmin = ValidateTokenForAdmin(token);
            if (!isAdmin)
            {
                res.ReturnAuthRequired("You are not authorized");
                res.Close();
                return;
            }
            res.AddHeader("Bearer", "new token");
            res.Write("your new token");

        }

        private bool ValidateTokenForAdmin(string token)
        {

            try
            {
                ClaimsPrincipal principal = GetPrincipal(token);
                if (principal == null)
                    return false;
                ClaimsIdentity identity = null;
                identity = (ClaimsIdentity)principal.Identity;
                if (identity == null)
                {
                    return false;
                }
                var roles = identity.FindAll(ClaimTypes.Role);
                bool isAdmin = false;
                foreach (var role in roles)
                {
                    if (role.Value == "Admin")
                    {
                        isAdmin = true;
                        break;
                    }
                }
                return isAdmin;
            }
            catch (SecurityTokenExpiredException)
            {
                //TODO handle
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public ClaimsPrincipal GetPrincipal(string token)
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
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
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
    }
}