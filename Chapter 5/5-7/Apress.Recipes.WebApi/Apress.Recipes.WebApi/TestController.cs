using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Apress.Recipes.WebApi
{
    [AutoInvalidateCacheOutput]
    public class TestController : ApiController
    {
        private readonly List<TestItem> Items = new List<TestItem>
        {
            new TestItem {Id = 1, Text = "Hello World", Time = DateTime.Now},
            new TestItem {Id = 2, Text = "Goodbye World", Time = DateTime.Now},
        };

        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        [Route("test/{id:int}")]
        public TestItem GetById(int id)
        {
            Console.WriteLine("hitting get by id");
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }

        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60, AnonymousOnly = true)]
        [Route("test")]
        public List<TestItem> Get()
        {
            Console.WriteLine("hitting get");
            return Items;
        }

        [Route("test")]
        public void Post(TestItem item)
        {
            Console.WriteLine("hitting post. this will invalidate cache");

            item.Id = Items.Last().Id + 1;
            Items.Add(item);
        }
    }
}