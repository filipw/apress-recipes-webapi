using System.Net.Http;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class HeadHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Head)
            {
                request.Method = HttpMethod.Get;
                request.Properties.Add("HeadMarker", true);
            }

            var response = await base.SendAsync(request, cancellationToken);

            object isHead;
            response.RequestMessage.Properties.TryGetValue("HeadMarker", out isHead);

            if (response.IsSuccessStatusCode && isHead != null && ((bool)isHead))
            {
                var oldContent = await response.Content.ReadAsByteArrayAsync();
                var content = new StringContent(string.Empty);
                content.Headers.Clear();

                foreach (var header in response.Content.Headers)
                {
                    content.Headers.Add(header.Key, header.Value);
                }

                content.Headers.ContentLength = oldContent.Length;
                response.Content = content;
            }

            return response;
        }
    }
}