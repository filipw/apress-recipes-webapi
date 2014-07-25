using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class DifferentProxyController : ApiController
    {
        [Route("different/{*anything}")]
        public string Get(string anything)
        {
            return "Handled by attribute routing: " + anything;
        }
    }
}