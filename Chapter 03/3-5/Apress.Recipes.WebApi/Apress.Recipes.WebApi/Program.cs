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

                Console.WriteLine(" --- ALPHA Constraint --- ");

                //direct routes (attribute routing)
                Get(client, address + "orders/invoice");
                Get(client, address + "orders/invoice234");

                //centralize routing
                Get(client, address + "proxy/alpha/invoice");
                Get(client, address + "proxy/alpha/invoice234");

                Console.WriteLine(" --- CUSTOM EMAIL Constraint --- ");

                //direct routes (attribute routing)
                Get(client, address + "orders/client/filip@example.com");
                Get(client, address + "orders/client/invalidstring");

                //centralize routing
                Get(client, address + "proxy/email/filip@example.com");
                Get(client, address + "proxy/email/invalidstring");
            }

            Console.ReadLine();
        }

        private static void Get(HttpClient client, string url)
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, url);
            var response = client.SendAsync(msg).Result;
            Console.WriteLine(msg.RequestUri);
            if (response.IsSuccessStatusCode)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine(response.StatusCode);
            Console.WriteLine();
        }
    }
}
