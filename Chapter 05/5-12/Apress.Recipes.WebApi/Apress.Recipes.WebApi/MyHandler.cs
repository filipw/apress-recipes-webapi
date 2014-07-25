using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class MyHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var reqId = request.GetCorrelationId().ToString();
            if (Global.Storage.TryAdd(reqId, request))
            {
                var result = await base.SendAsync(request, cancellationToken);

                object req;
                Global.Storage.TryRemove(reqId, out req);
                return result;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}