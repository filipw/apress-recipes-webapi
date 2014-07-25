using System;
using System.Net.Http;
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

                var response = client.GetAsync(address + "item").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine();

                var response2 = client.GetAsync(address + "item?includeError=true").Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
