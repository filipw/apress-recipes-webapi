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

                var meesage1 = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                meesage1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response1 = client.SendAsync(meesage1).Result;

                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                var meesage2 = new HttpRequestMessage(HttpMethod.Get, address + "items/2");
                meesage2.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response2 = client.SendAsync(meesage2).Result;

                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        } 
    }
}
