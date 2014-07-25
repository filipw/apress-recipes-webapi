using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class PolicySetterHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.Query.ToLower().Contains("includeerror=true"))
            {
                request.GetRequestContext().IncludeErrorDetail = true;
            }
            else
            {
                request.GetRequestContext().IncludeErrorDetail = false;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}