using System.Web.Http;
using System.Web.Http.OData.Builder;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Player>("Players");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
