using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MessageHandlers.Add(new MyHandler());
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }
}