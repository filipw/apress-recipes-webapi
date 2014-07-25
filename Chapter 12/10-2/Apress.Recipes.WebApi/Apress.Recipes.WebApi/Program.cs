using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:925";
            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                Console.WriteLine(client.GetStringAsync(address + "/Players").Result);
                Console.WriteLine();

                Console.WriteLine(client.GetStringAsync(address + "/Players(1)").Result);
                Console.WriteLine();

                Console.WriteLine(client.GetStringAsync(address + "/Players(1)?$select=Name").Result);
                Console.ReadLine();
            }
        }
    }
}
