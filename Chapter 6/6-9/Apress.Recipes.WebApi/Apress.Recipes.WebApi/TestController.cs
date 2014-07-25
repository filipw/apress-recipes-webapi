using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        public HttpResponseMessage Get()
        {
            var item = new Item
            {
                Id = 1,
                Name = "Filip"
            };

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ProtoBufContent(item)
            };
        }

        [Route("test")]
        public async Task<HttpResponseMessage> Post()
        {
            var item = await Request.Content.ReadAsProtoBuf<Item>();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ProtoBufContent(item)
            };
        }
    }
}