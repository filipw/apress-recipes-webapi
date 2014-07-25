using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemController : ApiController
    {
        private static List<Item> _items = new List<Item>
        {
            new Item {Id = 1, Text = "Hello"},
            new Item {Id = 2, Text = "World"},
            new Item {Id = 3, Text = "Goodbye"},
            new Item {Id = 4, Text = "Hell"}
        };

        [Route("items")]
        public HttpResponseMessage Get()
        {
            var rangeHeader = Request.Headers.Range;
            if (rangeHeader != null && rangeHeader.Unit == "Item" && rangeHeader.Ranges != null)
            {
                var rangeValue = rangeHeader.Ranges.FirstOrDefault();
                if (rangeValue != null)
                {
                    if ((!rangeValue.From.HasValue && !rangeValue.To.HasValue) || 
                        rangeValue.From > _items.Count || rangeValue.To > _items.Count) 
                        throw new HttpResponseException(HttpStatusCode.BadRequest);

                    var skip = (rangeValue.From ?? 0);
                    var take = (rangeValue.To ?? _items.Count) - rangeValue.From + 1;
                    var partialRes = Request.CreateResponse(HttpStatusCode.PartialContent,
                        _items.Skip((int) skip - 1).Take((int) take));
                    partialRes.Headers.AcceptRanges.Add("Item");
                    partialRes.Content.Headers.ContentRange = new ContentRangeHeaderValue(skip,
                        rangeValue.To ?? _items.Count, _items.Count) {Unit = "Item"};
                    return partialRes;
                }
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, _items);
            response.Headers.AcceptRanges.Add("Item");
            return response;
        }
    }
}