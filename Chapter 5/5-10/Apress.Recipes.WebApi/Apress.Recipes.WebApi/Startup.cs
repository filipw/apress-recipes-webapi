using System;
using System.Web.Http;
using System.Web.Http.Hosting;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new PolicySetterHandler());
            
            //global setting
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;

            appBuilder.UseWebApi(config);
        }
    }
}