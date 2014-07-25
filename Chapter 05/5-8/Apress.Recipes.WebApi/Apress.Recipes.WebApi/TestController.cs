using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    [Sample(Order = 3, Scope = "Controller")]
    [Sample(Order = 2, Scope = "Controller")]
    [Sample(Order = 1, Scope = "Controller")]
    public class TestController : ApiController
    {
        [Sample(Order = 2, Scope = "Action")]
        [Sample(Order = 1, Scope = "Action")]
        [Sample(Order = 3, Scope = "Action")]
        public string Get()
        {
            return "Example";
        }
    }
}