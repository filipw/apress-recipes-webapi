using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class VersionConstraint : IHttpRouteConstraint
    {
        private readonly int _version;

        public VersionConstraint(int version)
        {
            _version = version;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            var versionFinder = new VersionFinder();
            var version = versionFinder.GetVersionFromRequest(request);
            return _version == version;
        }
    }
}