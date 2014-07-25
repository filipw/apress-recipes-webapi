using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemController : ApiController
    {
        [Route("item")]
        [ValidateModelState]
        public Item Post(Item item)
        {
            //echo input
            return item;
        }
    }
}