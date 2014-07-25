using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemsController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Route("items")]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _itemService.GetItemsAsync();
        }

        [Route("items/{id:int}", Name = "ItemById")]
        public async Task<Item> Get(int id)
        {
            var result = await _itemService.GetById(id);
            if (result == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return result;
        }

        [Route("items")]
        public async Task<HttpResponseMessage> Post(Item item)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _itemService.SaveAsync(item);
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("ItemById", new { id = item.Id }));
            return response;
        }
    }
}