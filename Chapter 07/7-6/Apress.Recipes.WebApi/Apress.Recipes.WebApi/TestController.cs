using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Apress.Recipes.WebApi
{
    public class DemoController : ApiController
    {
        private readonly ITraceWriter _tracer;

        public DemoController()
        {
            _tracer = Request.GetConfiguration().Services.GetTraceWriter();
        }

        [Route("demo")]
        public HttpResponseMessage Get()
        {
            _tracer.Info(Request, ControllerContext.ControllerDescriptor.ControllerType.FullName, "I'm inside Get method!");

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }   

}