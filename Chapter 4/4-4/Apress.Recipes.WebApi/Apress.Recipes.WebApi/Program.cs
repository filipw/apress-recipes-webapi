using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
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
                
                var message1 = new HttpRequestMessage(HttpMethod.Post, address + "/my?Id=1&Message=hello");
                Print(client.SendAsync(message1).Result);

                var message2 = new HttpRequestMessage(HttpMethod.Post, address + "/my?Id=2");
                message2.Content = new FormUrlEncodedContent(new []{ new KeyValuePair<string, string>("Message", "Hello2") });
                Print(client.SendAsync(message2).Result);

                var message3 = new HttpRequestMessage(HttpMethod.Post, address + "/my");
                message3.Content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("Message", "Hello3"), new KeyValuePair<string, string>("Id", "3") });
                Print(client.SendAsync(message3).Result);

                Console.ReadLine();
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
    }
}
