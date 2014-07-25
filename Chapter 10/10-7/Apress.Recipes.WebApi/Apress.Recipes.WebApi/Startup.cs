using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new BasicAuthHandler());

            appBuilder.UseWebApi(config);
        }
    }
}