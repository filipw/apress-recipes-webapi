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
            config.Services.Replace(typeof(IExceptionHandler), new ContentNegotiatedExceptionHandler());

            appBuilder.UseWebApi(config);
        }
    }
}