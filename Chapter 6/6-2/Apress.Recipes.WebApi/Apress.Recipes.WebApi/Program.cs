using System;
using System.Diagnostics;
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
                
                var normalRequest = new HttpRequestMessage(HttpMethod.Get, address + "items");
                Console.WriteLine(normalRequest);
                var normalResponse = client.SendAsync(normalRequest).Result;
                Console.WriteLine(normalResponse);
                Console.WriteLine(normalResponse.Content.ReadAsStringAsync().Result);

                Console.WriteLine();
                Console.WriteLine();

                var rangeRequest = new HttpRequestMessage(HttpMethod.Get, address + "items");
                rangeRequest.Headers.Range = new RangeHeaderValue(from: 2, to: 4)
                {
                    Unit = "Item"
                };
                Console.WriteLine(rangeRequest);
                var rangeResponse = client.SendAsync(rangeRequest).Result;
                Console.WriteLine(rangeResponse);
                Console.WriteLine(rangeResponse.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        } 
    }
}
