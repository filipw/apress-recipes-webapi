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

                    var message = new HttpRequestMessage(HttpMethod.Get, address + "files");
                    var response = client.SendAsync(message).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                    var message2 = new HttpRequestMessage(HttpMethod.Get, address + "page.html");
                    var response2 = client.SendAsync(message2).Result;
                    Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                    var message1 = new HttpRequestMessage(HttpMethod.Get, address + "test");
                    var response1 = client.SendAsync(message1).Result;

                    Console.WriteLine(response1.Content.ReadAsStringAsync().Result);

                    Console.ReadLine();
            }
        } 
    }
}
