using System;
using System.Net.Http;
using System.Net.Http.Formatting;
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

                //model binders
                var message1 = new HttpRequestMessage(HttpMethod.Get, address + "collection/numbers/1,2,3,4");
                var message2 = new HttpRequestMessage(HttpMethod.Get, address + "collection/words/asp,net,web,api");
                
                var response1 = client.SendAsync(message1).Result;
                var response2 = client.SendAsync(message2).Result;
                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                //typeconverter
                var message3 = new HttpRequestMessage(HttpMethod.Get, address + "searchWithConverter?query=1,10,asp");
                var response3 = client.SendAsync(message3).Result;
                Console.WriteLine(response3.Content.ReadAsStringAsync().Result);

                //from URI
                var message4 = new HttpRequestMessage(HttpMethod.Get, address + "search?PageIndex=1&PageSize=5&StartsWith=asp");
                var response4 = client.SendAsync(message4).Result;
                Console.WriteLine(response4.Content.ReadAsStringAsync().Result);

                //from Body
                var message5 = new HttpRequestMessage(HttpMethod.Post, address + "test");
                message5.Content = new StringContent("7");
                message5.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response5 = client.SendAsync(message5).Result;
                Console.WriteLine(response5.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        } 
    }
}
