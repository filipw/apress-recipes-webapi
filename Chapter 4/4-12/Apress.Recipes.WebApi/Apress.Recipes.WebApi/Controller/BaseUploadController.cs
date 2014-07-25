using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi.Controller
{
    public abstract class BaseUploadController : ApiController
    {
        public virtual async Task<List<string>> PostToMemory()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var contents = new List<string>();

            foreach (HttpContent ctnt in provider.Contents)
            {
                var stream = await ctnt.ReadAsStreamAsync();

                if (stream.Length != 0)
                {
                    var sr = new StreamReader(stream);
                    contents.Add(sr.ReadToEnd());
                }
            }

            return contents;
        }
    }
}