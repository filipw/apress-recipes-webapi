using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class BinaryController : ApiController
    {
        private string _root;

        public BinaryController()
        {
            _root = Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\");
        }

        [Route("stream/{filename}")]
        public HttpResponseMessage GetStream(string filename)
        {
            var path = Path.Combine(_root, filename);
            if (!File.Exists(path))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "not found"));

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            
            return result;
        }

        [Route("bytearray/{filename}")]
        public HttpResponseMessage GetByteArray(string filename)
        {
            var path = Path.Combine(_root, filename);
            byte[] data = File.ReadAllBytes(path);
            if (data == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "not found"));

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(data);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return result;
        }

        [Route("multipart/{file1},{file2}")]
        public HttpResponseMessage Get(string file1, string file2)
        {
            var fileA = new StreamContent(new FileStream(Path.Combine(_root, file1), FileMode.Open));
            fileA.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            var fileB = new StreamContent(new FileStream(Path.Combine(_root, file2), FileMode.Open));
            fileA.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var content = new MultipartContent {fileA, fileB};
            result.Content = content;

            return result;
        }

    }
}