using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class MyFormatter : JsonMediaTypeFormatter
    {
        public IService Service { get; set; }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            if (Service != null)
            {
                Debug.WriteLine(Service.SaySomething("Something from a formatter"));
            }

            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            var formatter = base.GetPerRequestFormatterInstance(type, request, mediaType);
            Service = request.GetDependencyScope().GetService(typeof(IService)) as IService;
            return formatter;
        }
    }
}