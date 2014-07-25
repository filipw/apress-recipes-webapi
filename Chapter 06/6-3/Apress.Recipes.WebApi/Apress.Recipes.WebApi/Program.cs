using System;
using System.Net.Http;
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
                var response = client.GetAsync(address + "test").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                var message = new HttpRequestMessage(HttpMethod.Head, address + "test");
                var response2 = client.SendAsync(message).Result;
                Console.WriteLine(response2.StatusCode);
                Console.WriteLine(response2.Content.Headers.ContentLength);

                Console.ReadLine();
            }
        } 
    }
}
