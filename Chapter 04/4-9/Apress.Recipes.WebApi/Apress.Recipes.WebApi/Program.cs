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

                PrintResponse(client.GetAsync(address + "api/items.json").Result);
                PrintResponse(client.GetAsync(address + "api/items.xml").Result);

                PrintResponse(client.GetAsync(address + "api/items?format=json").Result);
                PrintResponse(client.GetAsync(address + "api/items?format=xml").Result);

                var message1 = new HttpRequestMessage(HttpMethod.Get, address + "api/items");
                message1.Headers.Add("ReturnType","json");
                var message2 = new HttpRequestMessage(HttpMethod.Get, address + "api/items");
                message2.Headers.Add("ReturnType", "xml");

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
