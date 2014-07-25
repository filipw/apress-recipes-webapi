using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            var address = "http://localhost:920/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                //direct routes (attribute routing)
                Get(client, address + "direct/items/getall");
                Get(client, address + "direct/items/get/1");
                Get(client, address + "direct/items/get/2");

                //centralize routing
                Get(client, address + "api/orders/getall");
                Get(client, address + "api/orders/get/1");
                Get(client, address + "api/orders/get/2");
            }

            Console.ReadLine();
        }

        private static void Get(HttpClient client, string url)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.SendAsync(msg).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            Console.WriteLine();
        }
    }
}
