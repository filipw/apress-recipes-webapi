using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            appBuilder.Use(typeof (LoggingMiddleware));
            appBuilder.UseWebApi(config);
        }
    }
}