using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test/{id:int}")]
        public string Get(int id, HttpRequestMessage req)
        {
            return id + " " + req.RequestUri;
        }

        [Route("test/{text:alpha}")]
        public string Get(string text)
        {
            return text + " " + Request.RequestUri;
        }

        [Route("testA")]
        public async Task<TestItem> Post(HttpRequestMessage req)
        {
            return await req.Content.ReadAsAsync<TestItem>();
        }

        [Route("testB")]
        public async Task<TestItem> Post()
        {
            return await Request.Content.ReadAsAsync<TestItem>();
        }
    }
}