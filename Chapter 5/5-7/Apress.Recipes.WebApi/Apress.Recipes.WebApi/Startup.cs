using System.Web.Http;
using Owin;
using WebApi.OutputCache.V2;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);
        }
    }
}