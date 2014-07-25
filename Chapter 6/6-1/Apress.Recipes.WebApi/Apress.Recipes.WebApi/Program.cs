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
                var response = client.GetAsync(address + "test/1").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                var response2 = client.GetAsync(address + "test/abc").Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);

                var item = new TestItem {Id = 10, Text = "Hello world"};
                
                var response3 = client.PostAsJsonAsync(address + "testA", item).Result;
                Console.WriteLine(response3.Content.ReadAsStringAsync().Result);

                var response4 = client.PostAsJsonAsync(address + "testB", item).Result;
                Console.WriteLine(response4.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        } 
    }
}
