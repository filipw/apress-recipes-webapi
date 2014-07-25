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
                var response1 = client.GetAsync(address + "test/1").Result;
                Console.WriteLine(response1.StatusCode);
            }

            Console.ReadLine();
        } 
    }
}
