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

                Send(HttpMethod.Get, client, address + "api/teams");
                Send(HttpMethod.Get, client, address + "api/teams/1");
                Send(HttpMethod.Get, client, address + "api/teams/1/players");

                //this should fail
                Send(HttpMethod.Get, client, address + "api/badorders/1");
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
