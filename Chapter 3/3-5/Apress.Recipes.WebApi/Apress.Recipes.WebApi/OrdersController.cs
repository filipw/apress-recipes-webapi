using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class OrdersController : ApiController
    {
        [Route("orders/{text:alpha}")]
        public HttpResponseMessage Get(string text)
        {
            return Request.CreateResponse(HttpStatusCode.OK, text);
        }

        [Route("orders/client/{text:email}")]
        public HttpResponseMessage GetByClient(string text)
        {
            return Request.CreateResponse(HttpStatusCode.OK, text);
        }
    }
}