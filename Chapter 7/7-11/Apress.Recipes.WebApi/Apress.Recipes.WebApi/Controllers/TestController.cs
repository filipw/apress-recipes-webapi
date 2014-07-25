using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apress.Recipes.WebApi.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Hello world";
        }

        public string Get(int id)
        {
            return "Hello world " + id;
        }

        public void Post(UserData userdata)
        {

        }
    }
}