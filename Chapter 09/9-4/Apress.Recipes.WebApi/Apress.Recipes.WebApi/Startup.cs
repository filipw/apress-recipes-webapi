using System.Web.Http;
using Ninject;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var kernel = new StandardKernel();
            kernel.Bind<IService>().To<HelloService>();
            config.DependencyResolver = new NinjectResolver(kernel);
            config.MessageHandlers.Add(new SampleHandler());
            config.Formatters.Clear();
            config.Formatters.Add(new MyFormatter());

            appBuilder.UseWebApi(config);
        }
    }
}