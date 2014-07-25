using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        public Item Get(int id)
        {
            return new Item { Id = id, Name = "PS4", Country = "Japan"};
        }
    }
}