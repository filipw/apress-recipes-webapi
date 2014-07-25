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

                var team = new Team {Id = 3, Name = "Los Angeles Kings"};

                var result = client.PostAsJsonAsync(address + "api/teams", team).Result;
                Console.WriteLine(result.StatusCode);
                Console.WriteLine(result.Headers.Location);

                Console.WriteLine();

                var result2 = client.GetAsync(result.Headers.Location).Result;
                Console.WriteLine(result2.StatusCode);
                Console.WriteLine(result2.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
