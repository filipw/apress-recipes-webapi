using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemController : ApiController
    {
        [Route("item")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [OverrideAuthorization]
        [Route("item/{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }

}