using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Apress.Recipes.WebApi.SelfHost
{
    public class HtmlController : ApiController
    {
        public HttpResponseMessage Get(string filename)
        {
            var response = new HttpResponseMessage
            {
                Content =
                    new StreamContent(File.Open(AppDomain.CurrentDomain.BaseDirectory + "/files/" + filename,
                        FileMode.Open))
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}