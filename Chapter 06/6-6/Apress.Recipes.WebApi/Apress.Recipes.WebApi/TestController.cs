using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test/{id:int}")]
        public TestItem Get(int id)
        {
            return new TestItem {Id = id, Text = "Hello World"};
        }
    }
}