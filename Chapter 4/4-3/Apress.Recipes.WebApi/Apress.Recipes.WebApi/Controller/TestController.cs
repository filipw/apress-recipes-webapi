using System.Web.Http;

namespace Apress.Recipes.WebApi.Controller
{
    public class TestController : ApiController
    {
        [Route("test")]
        public int Post([FromBody]int id)
        {
            return id;
        }

    }
}