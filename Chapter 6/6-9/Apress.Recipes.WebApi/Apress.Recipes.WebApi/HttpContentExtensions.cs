using System.Net.Http;
using System.Threading.Tasks;
using ProtoBuf;

namespace Apress.Recipes.WebApi
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsProtoBuf<T>(this HttpContent content)
        {
            return Serializer.Deserialize<T>(await content.ReadAsStreamAsync());
        }
    }
}