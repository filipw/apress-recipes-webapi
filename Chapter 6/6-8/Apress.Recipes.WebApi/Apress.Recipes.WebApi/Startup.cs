using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.apress.recipes.webapi+json"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.apress.recipes.webapi-v2+json"));

            appBuilder.UseWebApi(config);
        }
    }

    public class ItemsController : ApiController
    {
        [VersionedRoute("items/{id:int}")]
        public Item Get(int id)
        {
            return new Item { Id = id, Name = "PS4", Country = "Japan"};
        }
    }

    public class ItemsV2Controller : ApiController
    {
        [VersionedRoute("items/{id:int}", Version = 2)]
        [Route("v2/items/{id:int}")]
        public SuperItem Get(int id)
        {
            return new SuperItem { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
        }
    }
}