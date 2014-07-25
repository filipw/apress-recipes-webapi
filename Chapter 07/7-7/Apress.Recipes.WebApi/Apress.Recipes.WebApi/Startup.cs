using System.Web.Http;
using System.Web.Http.Tracing;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(ITraceWriter), new SignalRTraceWrapper(new NlogTraceWriter(), "trace"));

            appBuilder.MapSignalR();
            appBuilder.UseWebApi(config);
        }
    }
}