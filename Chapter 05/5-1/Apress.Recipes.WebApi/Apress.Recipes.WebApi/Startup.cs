using System;
using System.Web.Http;
using Owin;
using WebApiContrib.Caching;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.MessageHandlers.Add(new OwinCompatibleThrottlingHandler(new InMemoryThrottleStore(), ip => 10, TimeSpan.FromMinutes(1), "Only ten requests per minute allowed"));

            appBuilder.UseWebApi(config);
        }
    }
}