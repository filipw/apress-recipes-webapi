using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Apress.Recipes.WebApi
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public static Lazy<ILoggingService> LoggingService = new Lazy<ILoggingService>(() => new SampleLoggingService());

        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {

            LoggingService.Value.Log(context.Request.Uri.ToString());
            await Next.Invoke(context);
        }
    }
}