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
            var address = "http://localhost:9000/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                for (var i = 0; i < 20; i++)
                {
                    var response = client.GetAsync(address + "test/1").Result;
                    Print(response);

                    var response2 = client.GetAsync(address + "test").Result;
                    Print(response2);                    

                    Thread.Sleep(3000);
                }
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            Console.WriteLine(response);
            
            var body = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(body);
            Console.WriteLine();
        }
    }
}
