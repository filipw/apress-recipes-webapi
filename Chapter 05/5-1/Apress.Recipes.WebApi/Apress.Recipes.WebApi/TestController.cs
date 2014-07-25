using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Example";
        }
    }
}