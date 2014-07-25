using System.Collections.Generic;
using System.Web.Http;
using Apress.Recipes.WebApi.WebHost.Models;

namespace Apress.Recipes.WebApi.WebHost.Controllers
{
    public class ItemsController : ApiController
    {
        public Items Get()
        {
            var list = new List<Item>
            {
                new Item {Id = 1, Name = "Filip"}, 
                new Item {Id = 2, Name = "Not Filip"}
            };

            return new Items {Collection = list};
        }

        public Item GetById(int id)
        {
            return new Item {Id = id, Name = "Filip"};
        }
    }
}