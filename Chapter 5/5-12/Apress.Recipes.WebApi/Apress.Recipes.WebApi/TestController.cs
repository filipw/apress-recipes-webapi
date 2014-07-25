using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("Test")]
        public string Get()
        {
            return "Hello";
        }
    }
}