using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData;

namespace Apress.Recipes.WebApi
{
    public class ItemController : ApiController
    {
        private static readonly List<Item> _items = new List<Item>
        {
            new Item {Id = 1, Name = "Filip", Country = "Switzerland"},
            new Item {Id = 2, Name = "Felix", Country = "Canada"},
            new Item {Id = 3, Name = "Michal", Country = "Poland"}
        };

        [Route("traditional/{id:int}")]
        public Item Patch(int id, Item newItem)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            if (newItem.Name != null)
                item.Name = newItem.Name;

            if (newItem.Country != null)
                item.Country = newItem.Country;

            return item;
        }

        [Route("delta/{id:int}")]
        public Item Patch(int id, Delta<Item> newItem)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            newItem.Patch(item);

            return item;
        }

        [Route("custom/{id:int}")]
        public Item Patch(int id, IEnumerable<KeyValuePair<string, object>> updateProperties)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            foreach (var property in updateProperties)
            {
                Updater.Patch(item, property.Key, property.Value);   
            }

            return item;
        }
    }
}