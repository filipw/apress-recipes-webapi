using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var address = "http://localhost:9000/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, address + "stream");
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                var body = await response.Content.ReadAsStreamAsync();

                using (var reader = new StreamReader(body))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
