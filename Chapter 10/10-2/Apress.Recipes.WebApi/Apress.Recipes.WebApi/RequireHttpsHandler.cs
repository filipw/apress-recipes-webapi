using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class RequireHttpsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required"
                });

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}