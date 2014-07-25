using System.Web.Http;
using System.Web.Http.Controllers;
using Owin;

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