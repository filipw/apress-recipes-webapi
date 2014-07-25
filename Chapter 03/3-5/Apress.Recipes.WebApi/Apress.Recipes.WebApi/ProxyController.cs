using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ProxyController : ApiController
    {
        public string Get(string text)
        {
            return text;
        }
    }
}