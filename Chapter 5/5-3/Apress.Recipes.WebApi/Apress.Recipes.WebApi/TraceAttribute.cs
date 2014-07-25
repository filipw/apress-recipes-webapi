using System;
using System.Web.Http.Controllers;
using System.Web.Http.Tracing;

namespace Apress.Recipes.WebApi
{
    public class TraceAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings,
            HttpControllerDescriptor controllerDescriptor)
        {
            var traceWriter =
                new SystemDiagnosticsTraceWriter()
                {
                    MinimumLevel = TraceLevel.Info,
                    IsVerbose = false
                };

            controllerSettings.Services.Replace(typeof(ITraceWriter), traceWriter);
        }
    }
}