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

                var meesage1 = new HttpRequestMessage(HttpMethod.Get, address + "stream/hello.html");
                var response1 = client.SendAsync(meesage1).Result;

                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                var meesage2 = new HttpRequestMessage(HttpMethod.Get, address + "bytearray/hello.html");
                var response2 = client.SendAsync(meesage2).Result;

                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                var meesage3 = new HttpRequestMessage(HttpMethod.Get, address + "multipart/hello.html,hello2.html");
                var response3 = client.SendAsync(meesage3).Result;

                Console.WriteLine(response3.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        } 
    }
}
