using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        public HttpResponseMessage Get()
        {
            throw new Exception("Ooops!");
        }

    }
}