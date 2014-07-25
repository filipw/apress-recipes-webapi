using System.Collections.Generic;
using System.Net.Http.Headers;
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

            config.Routes.MapHttpRoute("defaultVersioned", "v{version}/{controller}/{id}", new { id = RouteParameter.Optional }, new { version = @"\d+" });
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.apress.recipes.webapi+json"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.apress.recipes.webapi-v2+json"));

            config.Services.Replace(typeof(IHttpControllerSelector), new VersionAwareControllerSelector(config));

            appBuilder.UseWebApi(config);
        }
    }
}