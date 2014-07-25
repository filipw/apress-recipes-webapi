using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            appBuilder.UseWebApi(config);
        }
    }
}