using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        public string Get()
        {
            return "Hello";
        }
    }
}