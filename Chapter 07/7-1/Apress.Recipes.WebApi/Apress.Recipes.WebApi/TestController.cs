using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test/{id:int}")]
        [ResourceRemoved]
        public HttpResponseMessage Get(int id)
        {
            if (id == 0)
            {
                throw new ResourceRemovedException();
            }

            return Request.CreateResponse(HttpStatusCode.OK, id);
        }

    }
}