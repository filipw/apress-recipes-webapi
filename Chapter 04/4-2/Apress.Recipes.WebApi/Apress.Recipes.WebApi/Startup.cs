using System.Web.Http;
using Owin;
using WebApiContrib.Formatting;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Add(new ProtoBufFormatter());

            appBuilder.UseWebApi(config);
        }
    }
}