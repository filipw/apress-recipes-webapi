using System.Globalization;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class OrdersController : ApiController
    {
        [LocalizedRoute("order", Name = "order")]
        public string Get()
        {
            return "This is a sample response";
        }

        [LocalizedRoute("order/{id:int}", Name = "orderById")]
        public string GetById(int id)
        {
            return "This a sample response with id " + id;
        }
    }
}