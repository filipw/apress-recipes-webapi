using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi.RemoteServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            appBuilder.UseWebApi(config);
        }
    }
}