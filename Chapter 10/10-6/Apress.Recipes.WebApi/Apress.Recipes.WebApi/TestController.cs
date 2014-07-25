using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    [Authorize]
    public class TestController : ApiController
    {
        [Route("test")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "hello from a secured resource!");
        }
    }
}