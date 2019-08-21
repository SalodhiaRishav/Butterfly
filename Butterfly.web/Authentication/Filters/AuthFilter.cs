using Microsoft.IdentityModel.Tokens;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Butterfly.web.Authentication.Filters
{
    public class AuthFilter : RequestFilterAttribute
    {
        public string RoleName { get; set; }
        private static string secret = System.Configuration.ConfigurationManager.AppSettings["secret"];
        public override void Execute(IHttpRequest req, IHttpResponse res, object requestDto)
        {
            string token = req.Headers.Get("Authorization");

            if (String.IsNullOrEmpty(token))
            {
                res.ReturnAuthRequired("You are not authorized");
                res.Close();
                return;
            }
            try
            {
                bool isAuthenticated = ValidateToken(token,RoleName);
                if (!isAuthenticated)
                {
                    res.ReturnAuthRequired("You are not authorized");
                    res.Close();
                    return;
                }
            }
            catch(SecurityTokenExpiredException)
            {
                res.Write("token expired");
                res.Close();
                return;
            }
          

        }

        private bool ValidateToken(string token,string roleName)
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
                bool isAuthenticated = false;
                foreach (var role in roles)
                {
                    if (role.Value == roleName)
                    {
                        isAuthenticated = true;
                        break;
                    }
                }
                return isAuthenticated;
            }
            catch (SecurityTokenExpiredException exception)
            {
                throw exception;
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
                if(DateTime.Compare(jwtToken.ValidTo,DateTime.UtcNow)<0)
                {
                    throw  new SecurityTokenExpiredException();
                }
                var tempTime = jwtToken.ValidFrom - jwtToken.ValidTo;
                var temptime = DateTime.UtcNow.Ticks;
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
            catch (Exception  e)
            {
                throw e;
            }
        }
    }
}