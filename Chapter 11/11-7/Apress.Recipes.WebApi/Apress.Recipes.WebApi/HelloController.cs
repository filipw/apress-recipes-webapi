using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class HelloController : ApiController
    {
        [Route("hello")]
        [Cache(ClientTimeSpan = 100)]
        public string Get()
        {
            return "Hello World";
        }

        [Route("hello")]
        public HttpResponseMessage Post(MessageDto message)
        {
            //pretend we process message here

            return Request.CreateResponse(HttpStatusCode.Created, message);
        }
    }

    public class MessageDto
    {
        public string Text { get; set; }
    }
}