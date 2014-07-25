using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        private readonly List<TestItem> Items = new List<TestItem>
        {
            new TestItem {Id = 1, Text = "Hello World", Time = DateTime.Now},
            new TestItem {Id = 2, Text = "Goodbye World", Time = DateTime.Now},
        };

        [Cache(Client = 10, Server = 10)]
        [Route("test/{id:int}")]
        public TestItem Get(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }

        [Cache(Client = 10, Server = 10)]
        [Route("test")]
        public List<TestItem> Get()
        {
            return Items;
        }

        [Route("test")]
        public void Post(TestItem item)
        {
            item.Id = Items.Last().Id + 1;
            Items.Add(item);
        }
    }
}