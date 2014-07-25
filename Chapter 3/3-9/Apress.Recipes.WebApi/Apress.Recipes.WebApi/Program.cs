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

                for (int i = 0; i < 5; i++)
                {
                    var meesage = new HttpRequestMessage(HttpMethod.Get, address + "api/public/items");
                    var response = client.SendAsync(meesage).Result;

                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine("Current log size {0}", Repository.Log.Count);

                    Console.WriteLine();
                    Thread.Sleep(300);
                }

                for (int i = 0; i < 5; i++)
                {
                    var meesage = new HttpRequestMessage(HttpMethod.Get, address + "api/items?apikey=somemadeupkey");
                    var response = client.SendAsync(meesage).Result;

                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine("Current log size {0}", Repository.Log.Count);

                    Console.WriteLine();
                    Thread.Sleep(300);
                }

                foreach (var entry in Repository.Log)
                {
                    Console.WriteLine(entry);
                }
            }

            Console.ReadLine();
        } 
    }
}
