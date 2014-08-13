using System.Web.Http;

namespace Apress.Recipes.WebApi.SelfHost
{
    public class RazorController : ApiController
    {
        public IHttpActionResult Get()
        {
            return new HtmlActionResult("Item", new Item { Id = 1, Name = "Filip"});
        }
    }
}