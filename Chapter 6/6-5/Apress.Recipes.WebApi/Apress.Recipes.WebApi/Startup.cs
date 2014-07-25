using System.Web.Http;
using System.Web.Http.Batch;
using System.Web.Http.Dispatcher;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpBatchRoute("WebApiBatch", "api/batch", 
                new DefaultHttpBatchHandler(new HttpServer(config, new HttpRoutingDispatcher(config))));
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            appBuilder.UseWebApi(config);
        }
    }
}