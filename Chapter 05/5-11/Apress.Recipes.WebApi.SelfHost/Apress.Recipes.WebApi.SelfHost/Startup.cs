using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi.SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "Razor", "razor/item",
                new { controller = "Razor" });

            config.Routes.MapHttpRoute(
                "HTML", "files/{filename}",
                new { controller = "Html" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            appBuilder.UseWebApi(config);
        }
    }
}