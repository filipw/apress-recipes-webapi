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
                Get(client, address + "different");
                Get(client, address + "different/1");
                Get(client, address + "different/2/hello");

                //centralize routing
                Get(client, address + "proxy");
                Get(client, address + "proxy/1");
                Get(client, address + "proxy/2/hello");
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
