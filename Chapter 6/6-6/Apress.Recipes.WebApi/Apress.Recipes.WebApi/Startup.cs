using System.Net.Http.Formatting;
using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            var negotiator = new DefaultContentNegotiator(excludeMatchOnTypeOnly: true);
            config.Services.Replace(typeof(IContentNegotiator), negotiator);

            config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);
        }
    }
}