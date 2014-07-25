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

                var response = client.PostAsJsonAsync(address + "item", new Item()).Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine();

                var response2 = client.PostAsJsonAsync<string>(address + "text", null).Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
