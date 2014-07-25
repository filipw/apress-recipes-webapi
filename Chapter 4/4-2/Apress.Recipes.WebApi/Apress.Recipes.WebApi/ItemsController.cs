using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        [Route("items")]
        public IEnumerable<Item> Get()
        {
            return new List<Item>
            {
                new Item {Id = 1, Name = "Filip"}, 
                new Item {Id = 2, Name = "Not Filip"}
            };
        }
    }
}