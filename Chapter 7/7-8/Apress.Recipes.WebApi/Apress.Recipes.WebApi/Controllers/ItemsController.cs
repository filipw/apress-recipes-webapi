using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apress.Recipes.WebApi.Controllers
{
    public class ItemsController : ApiController
    {
        public List<Item> Get()
        {
            var list = new List<Item>
            {
                new Item {Id = 1, Name = "Filip"}, 
                new Item {Id = 2, Name = "Not Filip"}
            };

            return list;
        }

        public Item Get(int id)
        {
            return new Item {Id = id, Name = "Filip"};
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void Post(int id)
        {
            //empty
        }
    }
}