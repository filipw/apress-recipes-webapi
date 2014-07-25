using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class AnotherController : ApiController
    {
        [Route("another")]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}