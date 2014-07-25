using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Apress.Recipes.WebApi
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        private static readonly string[] Extensions = { "txt", "log" };

        public CustomMultipartFormDataStreamProvider(string path)
            : base(path)
        { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var filename = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            if (filename.IndexOf('.') < 0)	
                throw new Exception("No extension");

            var extension = filename.Split('.').Last();
            if (!Extensions.Any(i => i.Equals(extension, StringComparison.InvariantCultureIgnoreCase)))
                throw new Exception("Extension not allowed!");

            return base.GetLocalFileName(headers);
        }
    }
}