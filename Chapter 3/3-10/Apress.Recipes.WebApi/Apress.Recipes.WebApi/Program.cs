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

                    var meesage = new HttpRequestMessage(HttpMethod.Get, address + "files");
                    //var meesage = new HttpRequestMessage(HttpMethod.Get, address + "page.html/abc=abc");
                    var response = client.SendAsync(meesage).Result;

                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                    var meesage1 = new HttpRequestMessage(HttpMethod.Get, address + "test");
                    var response1 = client.SendAsync(meesage1).Result;

                    Console.WriteLine(response1.Content.ReadAsStringAsync().Result);

                    Console.ReadLine();
            }

            
        } 
    }
}
