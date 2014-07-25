using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi.WebHost.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        [Route("test")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, User.Identity.Name);
        }
    }
}
