using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class OrdersController : ApiController
    {
        private static List<Order> orders = new List<Order>
        {
            new Order {Id = 1, Text = "Pizza"},
            new Order {Id = 2, Text = "Cola"}
        };

        public dynamic Get(int? id = null)
        {
            if (id == null)
                return orders;

            var order = orders.FirstOrDefault(x => x.Id == id);
            if (order == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return order;
        }
    }
}