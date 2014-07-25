using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test1")]
        public HttpResponseMessage GetVersion1()
        {
            var message = new ResponseDto
            {
                Message = "hello world"
            };

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<ResponseDto>(message, Configuration.Formatters.JsonFormatter)
            };

            return result;
        }

        [Route("test2")]
        public IHttpActionResult GetVersion2()
        {
            var message = new ResponseDto
            {
                Message = "hello world"
            };

            return Json(message);
        }

        [Route("test3")]
        public IHttpActionResult GetPlainText()
        {
            return new PlainTextResult("hello world", Encoding.UTF8);
        }
    }
}