using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}