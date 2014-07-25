using System;
using System.Net.Http;
using System.Net.Http.Headers;
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

                var message1 = new HttpRequestMessage(HttpMethod.Get, address + "test1");
                var response1 = client.SendAsync(message1).Result;

                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                var message2 = new HttpRequestMessage(HttpMethod.Get, address + "test2");
                var response2 = client.SendAsync(message2).Result;

                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                var message3 = new HttpRequestMessage(HttpMethod.Get, address + "test3");
                var response3 = client.SendAsync(message3).Result;

                Console.WriteLine(response3.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        } 
    }
}
