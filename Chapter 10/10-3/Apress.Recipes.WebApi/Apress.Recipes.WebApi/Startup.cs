using System.Net;
using System.Web.Http;
using Owin;
using Thinktecture.IdentityModel.WebApi.Authentication.Handler;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var authenticationConfiguration = new AuthenticationConfiguration
            {
                RequireSsl = false
            };

            authenticationConfiguration.AddBasicAuthentication((userName, password) =>
            {
                return userName == "filip" && password == "abc";
            }, AuthenticationOptions.ForHeader("MyAuthorization"));

            config.MessageHandlers.Add(new AuthenticationHandler(authenticationConfiguration));
            appBuilder.UseWebApi(config);
        }
    }
}