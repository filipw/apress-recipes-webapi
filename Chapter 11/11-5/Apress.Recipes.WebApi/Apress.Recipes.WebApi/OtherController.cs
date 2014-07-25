using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class OtherController : ApiController
    {
        [Route("id:int", Name = "Other")]
        public Item Get(int id)
        {
            return new Item {Id = id, Name = "Filip"};
        }
    }
}