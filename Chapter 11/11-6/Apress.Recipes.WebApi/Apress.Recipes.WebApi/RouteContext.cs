using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Apress.Recipes.WebApi
{
    public class RouteContext
    {
        private readonly IEnumerable<HttpActionDescriptor> _actionMappings;

        public RouteContext(HttpConfiguration config, HttpRequestMessage request)
        {
            var routeData = config.Routes.GetRouteData(request);
            request.SetRouteData(routeData);

            var controllerSelector = new DefaultHttpControllerSelector(config);
            var descriptor = controllerSelector.SelectController(request);
            ControllerType = descriptor.ControllerType;

            var actionSelector = new ApiControllerActionSelector();
            _actionMappings = actionSelector.GetActionMapping(descriptor).SelectMany(x => x).Where(x => x.SupportedHttpMethods.Contains(request.Method));
        }

        public Type ControllerType { get; private set; }

        public bool VerifyMatchedAction(MethodInfo method)
        {
            return _actionMappings.Any(item => ((ReflectedHttpActionDescriptor)item).MethodInfo.ToString() == method.ToString());
        }
    }
}