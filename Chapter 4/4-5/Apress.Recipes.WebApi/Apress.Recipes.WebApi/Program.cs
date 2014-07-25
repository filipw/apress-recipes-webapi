using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

                var message1 = new HttpRequestMessage(HttpMethod.Get, address + "items");
                message1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message2 = new HttpRequestMessage(HttpMethod.Get, address + "items");
                message2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                PrintResponse(client.SendAsync(message1).Result);
                PrintResponse(client.SendAsync(message2).Result);

                Console.ReadLine();
            }
        }

        private static void PrintResponse(HttpResponseMessage response)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine();
        }
    }
}
