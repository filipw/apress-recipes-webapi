using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class ResourceRemovedAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ResourceRemovedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.Gone);
            }
        }
    }
}