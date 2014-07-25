using System.Web.Http;
using Owin;
using TinyIoC;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var container = new TinyIoCContainer();
            container.Register<IService, HelloService>();

            config.DependencyResolver = new TinyIoCResolver(container);
            appBuilder.UseWebApi(config);
        }
    }
}