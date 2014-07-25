using System;
using System.Data;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Apress.Recipes.WebApi
{
    public class VersionAwareControllerSelector : DefaultHttpControllerSelector
    {
        public VersionAwareControllerSelector(HttpConfiguration configuration) : base(configuration) { }

        public override string GetControllerName(HttpRequestMessage request)
        {
            var controllerName = base.GetControllerName(request);
            var versionFinder = new VersionFinder();
            var version = versionFinder.GetVersionFromRequest(request);

            if (version > 0)
            {
                return GetVersionedControllerName(request, controllerName, version);
            }

            return controllerName;
        }

        private string GetVersionedControllerName(HttpRequestMessage request, string baseControllerName, int version)
        {
            var versionControllerName = string.Format("{0}v{1}", baseControllerName, version);
            HttpControllerDescriptor descriptor;
            if (GetControllerMapping().TryGetValue(versionControllerName, out descriptor))
            {
                return versionControllerName;
            }

            throw new HttpResponseException(request.CreateErrorResponse(
                    HttpStatusCode.NotFound,
                    String.Format("No HTTP resource was found that matches the URI {0} and version number {1}",
                        request.RequestUri, version)));
        }
    }
}