using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        [Route("items/{id:int}", Name = "Items")]
        public HttpResponseMessage Get(int id)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Redirect);
            var link = Url.Link("Other", new { id = id });
            response.Headers.Location = new Uri(link);
            
            return response;
        }

        [Route("newItems/{id:int}", Name = "NewItems")]
        public IHttpActionResult GetNewItems(int id)
        {
            return RedirectToRoute("Other", new { id = id });
        }
    }
}