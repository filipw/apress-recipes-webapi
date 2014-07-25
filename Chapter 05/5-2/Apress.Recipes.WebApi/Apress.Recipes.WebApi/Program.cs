using System;
using System.Net.Http;
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

                var response = client.GetAsync(address + "api/hello").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                var response2 = client.GetAsync(address + "api/unreferenced").Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}
