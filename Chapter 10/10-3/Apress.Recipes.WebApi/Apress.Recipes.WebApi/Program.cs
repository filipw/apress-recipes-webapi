using System;
using System.Net;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using Thinktecture.IdentityModel.Http;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            var address = "http://localhost:925/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();
                var response = client.GetAsync(address + "test").Result;
                Console.WriteLine(response.StatusCode);

                Console.WriteLine();
                Console.WriteLine("Next request sets basic authentication password");

                client.SetBasicAuthentication("filip", "abc");
                var response2 = client.GetAsync(address + "test").Result;
                Console.WriteLine(response2.StatusCode);

                Console.ReadLine();
            }
        }
    }
}
