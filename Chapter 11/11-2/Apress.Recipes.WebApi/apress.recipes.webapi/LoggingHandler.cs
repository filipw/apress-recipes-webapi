using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class LoggingHandler : DelegatingHandler
    {
        public ILoggingService LoggingService { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var loggingService = LoggingService ?? request.GetDependencyScope().GetService(typeof (ILoggingService)) as ILoggingService;
            if (loggingService != null)
            {
                loggingService.Log(request.RequestUri.ToString());    
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}