using System.Net.Http;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsProtoBufAsync<T>(this HttpClient client, string address, T obj)
        {
            return await client.PostAsync(address, new ProtoBufContent(obj));
        }
    }
}