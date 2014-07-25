using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        [Route("items/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var item = new Item
            {
                Id = id,
                Name = "I'm manually content negotiatied!"
            };
            var negotiator = Configuration.Services.GetContentNegotiator();
            var result = negotiator.Negotiate(typeof(Item), Request, Configuration.Formatters);

            var bestMatchFormatter = result.Formatter;
            var mediaType = result.MediaType.MediaType;

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Item>(item, bestMatchFormatter, mediaType)
            };
        }

    }
}