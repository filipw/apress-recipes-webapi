using System.Web.Http;

namespace Apress.Recipes.WebApi.Controller
{
    public class SearchController : ApiController
    {
        [Route("searchWithConverter")]
        public string Get(ConvertedSearchQuery query)
        {
            return string.Format("PageIndex: {0}, pageSize: {1}, StartsWith: {2}", query.PageIndex, query.PageSize, query.StartsWith);
        }

        [Route("search")]
        public string Get([FromUri]SearchQuery query)
        {
            return string.Format("PageIndex: {0}, pageSize: {1}, StartsWith: {2}", query.PageIndex, query.PageSize, query.StartsWith);
        }
    }
}