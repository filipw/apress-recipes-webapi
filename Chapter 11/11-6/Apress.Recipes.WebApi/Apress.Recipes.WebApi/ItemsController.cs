using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        public IEnumerable<Item> GetAll()
        {
            return new List<Item> {new Item {Id = 1, Name = "Filip"}, new Item {Id = 1, Name = "NotFilip"}};
        }

        public Item Get(int id)
        {
            return new Item {Id = id, Name = "Filip"};
        }

        public void Post(Item item)
        {
        }

        public void Delete(int id)
        {
        }
    }
}