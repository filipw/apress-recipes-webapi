using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:925/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var response = client.GetAsync(address + "files/test.html").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                var response2 = client.GetAsync(address + "razor/item").Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);


                Console.ReadLine(); 
            }
        }
    }
}
