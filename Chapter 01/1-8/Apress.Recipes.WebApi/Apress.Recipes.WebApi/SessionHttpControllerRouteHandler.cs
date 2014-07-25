using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;

namespace Apress.Recipes.WebApi
{
    public class SessionHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionControllerHandler(requestContext.RouteData);
        }
    }
}