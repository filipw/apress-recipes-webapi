using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Apress.Recipes.WebApi
{
    public class DemoController : ApiController
    {
        [Route("demo")]
        public string Get()
        {
            var tracer = Request.GetConfiguration().Services.GetTraceWriter();
            tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "I'm inside Get method!");

            return "Hello world!";
        }
    }
}