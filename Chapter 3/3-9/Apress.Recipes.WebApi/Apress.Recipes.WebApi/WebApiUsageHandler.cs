using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class Repository
    {
        public static readonly List<string> Log = new List<string>();
    }

    public class WebApiUsageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var apikey = request.GetQueryString("apikey");

            if (!string.IsNullOrWhiteSpace(apikey))
            {
                Repository.Log.Add(string.Format("{0} {1} {2}", apikey, request.Method, request.RequestUri));
                var result = await base.SendAsync(request, cancellationToken);
                Repository.Log.Add(string.Format("{0} {1}", apikey, result.StatusCode));
                
                return result;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}