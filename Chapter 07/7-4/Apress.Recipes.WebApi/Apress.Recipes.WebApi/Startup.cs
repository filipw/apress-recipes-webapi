using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            
            config.EnableSystemDiagnosticsTracing();

            appBuilder.UseWebApi(config);
        }
    }
}