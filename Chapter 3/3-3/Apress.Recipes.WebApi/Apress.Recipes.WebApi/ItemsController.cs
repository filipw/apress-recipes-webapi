using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        private static List<Item> items = new List<Item>
            {
                new Item {Id = 1, Name = "Filip"},
                new Item {Id = 2, Name = "Not Filip"}
            };

        [Route("items/{id:int=1}")]
        public Item Get(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }
    }
}