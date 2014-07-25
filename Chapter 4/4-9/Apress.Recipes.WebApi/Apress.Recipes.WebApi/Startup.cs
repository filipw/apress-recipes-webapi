using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "Api UriPathExtension",
                routeTemplate: "api/{controller}.{ext}/{id}",
                defaults: new {id = RouteParameter.Optional, extension = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "Api UriPathExtension ID",
                routeTemplate: "api/{controller}/{id}.{ext}",
                defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "application/xml");

            config.Formatters.JsonFormatter.AddQueryStringMapping("format", "json", "application/json");
            config.Formatters.XmlFormatter.AddQueryStringMapping("format", "xml", "application/xml");

            config.Formatters.JsonFormatter.AddRequestHeaderMapping("ReturnType", "json",
                StringComparison.InvariantCultureIgnoreCase, false, "application/json");
            config.Formatters.XmlFormatter.AddRequestHeaderMapping("ReturnType", "xml",
                StringComparison.InvariantCultureIgnoreCase, false, "application/xml");

            appBuilder.UseWebApi(config);
        }
    }
}