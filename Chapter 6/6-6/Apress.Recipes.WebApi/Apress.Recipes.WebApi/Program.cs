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
                var supportedMessage = new HttpRequestMessage(HttpMethod.Get, address + "test/1");
                supportedMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result1 = client.SendAsync(supportedMessage).Result;
                Print(result1);
                
                var unSupportedMessage = new HttpRequestMessage(HttpMethod.Get, address + "test/1");
                unSupportedMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var result2 = client.SendAsync(unSupportedMessage).Result;
                Print(result2);

                Console.ReadLine();
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
