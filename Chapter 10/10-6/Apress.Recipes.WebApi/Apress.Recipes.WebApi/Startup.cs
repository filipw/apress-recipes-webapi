using System;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var oauthProvider = new OAuthAuthorizationServerProvider
            {
                OnGrantResourceOwnerCredentials = async context =>
                {
                    if (context.UserName == "filip" && context.Password == "xxx")
                    {
                        var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                        claimsIdentity.AddClaim(new Claim("user", context.UserName));
                        context.Validated(claimsIdentity);
                        return;
                    }
                    context.Rejected();
                },
                OnValidateClientAuthentication = async context =>
                {
                    string clientId;
                    string clientSecret;
                    if (context.TryGetBasicCredentials(out clientId, out clientSecret))
                    {
                        if (clientId == "filipClient" && clientSecret == "secretKey")
                        {
                            context.Validated();
                        }
                    }
                }
            };
            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/accesstoken"),
                Provider = oauthProvider
            };
            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}