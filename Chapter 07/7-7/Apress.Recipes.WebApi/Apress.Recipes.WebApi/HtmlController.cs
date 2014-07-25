using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class HtmlController : ApiController
    {
        [Route("traceviewer")]
        [HttpGet]
        public HttpResponseMessage Viewer()
        {
            var file = File.Open(Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\log.html"), FileMode.Open);
            var res = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(file)
            };
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return res;
        }
    }
}