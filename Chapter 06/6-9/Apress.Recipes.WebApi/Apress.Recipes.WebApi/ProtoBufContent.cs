using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProtoBuf;

namespace Apress.Recipes.WebApi
{
    public class ProtoBufContent : HttpContent
    {
        private readonly MemoryStream _stream;

        public ProtoBufContent(object model)
        {
            _stream = new MemoryStream();
            Serializer.Serialize(_stream, model);
            _stream.Position = 0;
            Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            if (!_stream.CanSeek)
            {
                length = 0;
                return false;
            }

            length = _stream.Length;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            _stream.Dispose();
        }
    }
}