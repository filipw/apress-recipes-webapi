using System.Collections.Generic;
using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes(new LocalizedDirectRouteProvider());
            appBuilder.UseWebApi(config);

            LocalizedRouteAttribute.Routes.Add("order", new Dictionary<string, string>
            {
                { "de-CH", "auftrag" },
                { "pl-PL", "zamowienie" }
            });

            LocalizedRouteAttribute.Routes.Add("orderById", new Dictionary<string, string>
            {
                { "de-CH", "auftrag/{id:int}" },
                { "pl-PL", "zamowienie/{id:int}" }
            });
        }
    }
}