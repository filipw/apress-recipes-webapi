using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "PublicDefaultApi",
                routeTemplate: "api/public/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PrivateDefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new WebApiUsageHandler() { InnerHandler = new HttpControllerDispatcher(config) }
            );

            appBuilder.UseWebApi(config);
        }
    }
}