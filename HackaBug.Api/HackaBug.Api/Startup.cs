using System;
using System.Web.Http;
using HackaBug.Api.Authorization;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace HackaBug.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            config.EnableCors();
            ConfigureOAuth(app);
        }
        public static void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                // AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}