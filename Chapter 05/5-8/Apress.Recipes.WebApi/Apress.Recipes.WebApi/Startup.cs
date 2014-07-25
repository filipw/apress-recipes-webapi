using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Services.Add(typeof(IFilterProvider), new OrderBasedFilterProvider());
            var providers = config.Services.GetFilterProviders();
            
            var defaultprovider = providers.First(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);

            var configprovider = providers.First(i => i is ConfigurationFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), configprovider);

            config.Filters.Add(new SampleAttribute { Order = 2, Scope = "Global"});
            config.Filters.Add(new SampleAttribute { Order = 1, Scope = "Global" });

            appBuilder.UseWebApi(config);
        }
    }

    
}