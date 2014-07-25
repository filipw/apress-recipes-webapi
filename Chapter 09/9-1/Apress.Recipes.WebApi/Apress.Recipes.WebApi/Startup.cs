using System.Web.Http;
using System.Web.Http.Dispatcher;
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
            config.Services.Replace(typeof(IHttpControllerActivator), new TinyIoCHttpControllerActivator(container));
            //config.Services.Replace(typeof(IHttpControllerActivator), new SimpleHttpControllerActivator());

            appBuilder.UseWebApi(config);
        }
    }
}