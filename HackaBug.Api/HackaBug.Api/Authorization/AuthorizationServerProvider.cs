using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace HackaBug.Api.Authorization
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var user = context.Request.Headers;
            context.Validated();
            return Task.FromResult<object>(user);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origen", new[] { "*" });
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET", "PUT", "POST", "DELETE", "OPTIONS" });
                 context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type" });
                
                    return Task.FromResult<object>(null);
                
            }
            catch (Exception e)
            {
                context.SetError("invalid_grant", e.Message);
                return Task.FromResult<object>(null);
            }
        }
    }
}