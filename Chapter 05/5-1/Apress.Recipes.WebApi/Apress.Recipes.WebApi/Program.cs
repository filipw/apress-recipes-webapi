using System;
using System.Linq;
using System.Net.Http;
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

                for (var i = 1; i < 15; i++)
                {
                    var response = client.GetAsync(address + "api/test").Result;
                    Console.WriteLine("Status code: {0}", response.StatusCode);
                    Console.WriteLine("Rate limit: {0}", response.Headers.GetValues("RateLimit-Limit").FirstOrDefault());
                    Console.WriteLine("Remaining limit: {0}", response.Headers.GetValues("RateLimit-Remaining").FirstOrDefault());
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }

                Console.ReadLine();
            }
        }
    }
}
