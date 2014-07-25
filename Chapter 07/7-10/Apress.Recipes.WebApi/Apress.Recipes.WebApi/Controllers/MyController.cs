using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apress.Recipes.WebApi.Controllers
{
    [Authorize]
    public class MyController : ApiController
    {
        public string Get()
        {
            return "Hello world";
        }

        [Cached]
        public string Get(int id)
        {
            return "Hello world " + id;
        }
    }

}