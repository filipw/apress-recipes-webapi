using System.Net.Http.Headers;

namespace Apress.Recipes.WebApi
{
    public class WebApiCacheItem
    {
        public WebApiCacheItem(MediaTypeHeaderValue contentType, byte[] content)
        {
            Content = content;
            ContentType = contentType.MediaType;
        }

        public string ContentType { get; private set; }
        public byte[] Content { get; private set; }

        public bool IsValid()
        {
            return Content != null && ContentType != null;
        }
    }
}