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
            var files = new[]
            {
                Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\textfile.txt"),
                Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\evilfile.bat")
            };

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var message1 = new HttpRequestMessage(HttpMethod.Post, address + "upload")
                {
                    Content = GetContentToUpload(files)
                };

                var result1 = client.SendAsync(message1).Result;
                Console.WriteLine(result1.StatusCode);

                Console.WriteLine();

                var message2 = new HttpRequestMessage(HttpMethod.Post, address + "uploadToMemory")
                {
                    Content = GetContentToUpload(files)
                };

                var result2 = client.SendAsync(message2).Result;
                Console.WriteLine(result2.Content.ReadAsStringAsync().Result);
                Console.WriteLine(result2.StatusCode);

                Console.ReadLine();
            }
        }

        private static HttpContent GetContentToUpload(string[] files)
        {
            var content = new MultipartFormDataContent();

            for (var i = 0; i < files.Length; i++)
            {
                var filestream = new FileStream(files[i], FileMode.Open);
                var fileName = System.IO.Path.GetFileName(files[i]);
                content.Add(new StreamContent(filestream), "file"+i, fileName);   
            }

            return content;
        }
    }
}
