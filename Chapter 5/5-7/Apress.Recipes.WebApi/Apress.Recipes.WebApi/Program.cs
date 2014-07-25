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

                for (var i = 0; i < 5; i++)
                {
                    var response = client.GetAsync(address + "test/1").Result;
                    Console.WriteLine(response.RequestMessage.RequestUri);
                    Console.WriteLine(response.StatusCode);

                    Console.WriteLine();

                    var response2 = client.GetAsync(address + "test").Result;
                    Console.WriteLine(response2.RequestMessage.RequestUri);
                    Console.WriteLine(response2.StatusCode);

                    Console.WriteLine();

                    Thread.Sleep(1000);
                }

                var response3 = client.PostAsJsonAsync(address + "test", new TestItem()).Result;
                Console.WriteLine(response3.RequestMessage.RequestUri);
                Console.WriteLine(response3.StatusCode);

                Console.WriteLine();

                for (var i = 0; i < 5; i++)
                {
                    var response = client.GetAsync(address + "test/1").Result;
                    Console.WriteLine(response.RequestMessage.RequestUri);
                    Console.WriteLine(response.StatusCode);

                    Console.WriteLine();

                    var response2 = client.GetAsync(address + "test").Result;
                    Console.WriteLine(response2.RequestMessage.RequestUri);
                    Console.WriteLine(response2.StatusCode);

                    Console.WriteLine();

                    Thread.Sleep(1000);
                }

                Console.ReadKey();
            }
        }
    }
}
