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
                var item = response.Content.ReadAsProtoBuf<Item>().Result;
                Print(item);

                var itemToSend = new Item {Id = 10, Name = "NotFilip"};
                var responseTwo = client.PostAsProtoBufAsync(address + "test", itemToSend).Result;
                var itemTwo = responseTwo.Content.ReadAsProtoBuf<Item>().Result;
                Print(itemTwo);

                Console.ReadLine();
            }
        }

        private static void Print(Item item)
        {
            Console.WriteLine();
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
        }
    }
}
