using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi
{
    public class RssMediaTypeFormatter : MediaTypeFormatter
    {
        private readonly string rss = "application/rss+xml";

        public RssMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(rss));
        }

        Func<Type, bool> typeisIRss = (type) => typeof(IRss).IsAssignableFrom(type);
        Func<Type, bool> typeisIRssCollection = (type) => typeof(IEnumerable<IRss>).IsAssignableFrom(type);

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeisIRss(type) || typeisIRssCollection(type);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            return Task.Factory.StartNew(() =>
            {
                RssFeedBuilder builder;
                if (typeisIRss(type))
                    builder = new RssFeedBuilder((IRss)value);
                else
                    builder = new RssFeedBuilder((IEnumerable<IRss>)value);

                builder.BuildSyndicationFeed(writeStream, content.Headers.ContentType.MediaType);
            });
        }
    }
}