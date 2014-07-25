using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class StreamController : ApiController
    {
        private const string Lipsum =
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi ut urna eget est lacinia pulvinar. In ultrices cursus justo vitae interdum. Sed sed erat turpis. Duis scelerisque, turpis at egestas euismod, dolor massa bibendum nulla, sed placerat diam arcu in lorem. Aliquam vehicula id sapien ut volutpat. Sed placerat lorem arcu, at ultrices lacus lobortis vel. Morbi condimentum nibh mollis sapien condimentum, non vehicula urna porta. Phasellus vel tempor erat. Interdum et malesuada fames ac sed.";

        [Route("stream")]
        public HttpResponseMessage Get()
        {

            var resp = new HttpResponseMessage
            {
                Content = new PushStreamContent(async (respStream, content, context) =>
                {
                    try
                    {
                        var wordsToSend = Lipsum.Split(' ');
                        using (var writer = new StreamWriter(respStream))
                        {
                            foreach (var word in wordsToSend)
                            {
                                await writer.WriteLineAsync(word);
                                await writer.FlushAsync();
                                await Task.Delay(millisecondsDelay: 250);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                    finally
                    {
                        respStream.Close();
                    }
                }, "text/plain")
            };

            return resp;
        }
    }
}