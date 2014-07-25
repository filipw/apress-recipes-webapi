using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsV2Controller : ApiController
    {
        public SuperItem Get(int id)
        {
            return new SuperItem { Id = id, Name = "Xbox One", Country = "USA", Price = 529.99 };
        }
    }
}