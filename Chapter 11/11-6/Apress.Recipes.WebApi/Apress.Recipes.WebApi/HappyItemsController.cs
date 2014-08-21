using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    [RoutePrefix("coolitems")]
    public class HappyItemsController : ApiController
    {
        [Route("")]
        public IEnumerable<Item> GetAll()
        {
            return new List<Item> { new Item { Id = 1, Name = "Filip" }, new Item { Id = 1, Name = "NotFilip" } };
        }

        [Route("{id:int}")]
        public Item Get(int id)
        {
            return new Item { Id = id, Name = "Filip" };
        }

        [Route("")]
        public void Post(Item item)
        {
        }

        [Route("{id:int}")]
        public void Delete(int id)
        {
        }
    }
}