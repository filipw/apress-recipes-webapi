using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());

            appBuilder.UseWebApi(config);
        }
    }
}