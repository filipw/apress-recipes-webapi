using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using Ninject.Activation;

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
                var response = client.GetAsync(address + "dependency").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        } 
    }
}
