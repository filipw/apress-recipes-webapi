using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class LocalizedDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyCollection<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            var routeAttributes = base.GetActionRouteFactories(actionDescriptor).ToList();
            foreach (var directRouteFactory in routeAttributes.Where(x => x is LocalizedRouteAttribute).ToList())
            {
                var localizedRoute = directRouteFactory as LocalizedRouteAttribute;
                if (localizedRoute != null)
                {
                    routeAttributes.AddRange(localizedRoute.GetLocalizedVersions());
                }
            }

            return routeAttributes;
        }
    }
}