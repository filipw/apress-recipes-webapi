using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    //note scope is not needed here, only added for illustartive purposes, so that we can print out the scope context information!
    [Third(Scope = "Controller")]
    [Second(Scope = "Controller")]
    [First(Scope = "Controller")]
    public class TestController : ApiController
    {
        [Second(Scope = "Action")]
        [First(Scope = "Action")]
        [Third(Scope = "Action")]
        public string Get()
        {
            return "Example";
        }
    }
}