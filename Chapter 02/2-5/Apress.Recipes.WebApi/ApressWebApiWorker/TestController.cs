using System.Web.Http;

namespace ApressWebApiWorker
{
    public class TestController : ApiController
    {
        [Route("test")]
        public string Get() { return "Hello Azure!"; }
    }
}