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

                //centralized routing
                Send(HttpMethod.Get, client, address + "api/orders/getall");
                Send(HttpMethod.Post, client, address + "api/orders/sillyaction");
                Send(HttpMethod.Post, client, address + "api/orders/sillynonaction");
            }

            Console.ReadLine();
        }

        private static void Send(HttpMethod method, HttpClient client, string url)
        {
            var msg = new HttpRequestMessage(method, url);
            var response = client.SendAsync(msg).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine(response.StatusCode);

            Console.WriteLine();
        }
    }
}
