using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;
using WebApiContrib.Tracing.Nlog;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(ITraceWriter), new NlogTraceWriter());

            appBuilder.UseWebApi(config);
        }
    }
}