using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        private static readonly List<Item> items = new List<Item>();

        public IEnumerable<Item> Get()
        {
            return items;
        }

        public void Post(Item item)
        {
            items.Add(item);
        }
    }
}