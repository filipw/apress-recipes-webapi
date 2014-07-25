using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            var address = "http://localhost:9000/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var message1 = new HttpRequestMessage(HttpMethod.Post, address + "upload")
                {
                    Content = GetContentToUpload()
                };

                var result1 = client.SendAsync(message1).Result;
                Console.WriteLine(result1.StatusCode);

                Console.WriteLine();

                var message2 = new HttpRequestMessage(HttpMethod.Post, address + "uploadToMemory")
                {
                    Content = GetContentToUpload()
                };

                var result2 = client.SendAsync(message2).Result;
                Console.WriteLine(result2.Content.ReadAsStringAsync().Result);
                Console.WriteLine(result2.StatusCode);

                Console.ReadLine();
            }
        }

        private static HttpContent GetContentToUpload()
        {
            var content = new MultipartFormDataContent();
            var file = Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\textfile.txt");
            var filestream = new FileStream(file, FileMode.Open);
            var fileName = System.IO.Path.GetFileName(file);
            content.Add(new StreamContent(filestream), "file", fileName);
            return content;
        }
    }
}
