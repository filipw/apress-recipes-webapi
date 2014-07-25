using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http.OData.Formatter;
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
                var item = new Item()
                {
                    Id = 50,
                    Country = "Scotland",
                    Name = "Richard"
                };
                var client = new HttpClient();
                var msg = new HttpRequestMessage(new HttpMethod("PATCH"), address + "delta/1")
                {
                    Content = new ObjectContent(typeof (Item), item, new JsonMediaTypeFormatter())
                };
                var response = client.SendAsync(msg).Result;
                Print(response);

                var postData = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("Id", 100),
                    new KeyValuePair<string, object>("Country", "Finland"),
                    new KeyValuePair<string, object>("Name", "Sami")
                };
                var msgTwo = new HttpRequestMessage(new HttpMethod("PATCH"), address + "custom/2")
                {
                    Content = new ObjectContent(typeof(IEnumerable<KeyValuePair<string, object>>), postData, new JsonMediaTypeFormatter())
                };
                var responseTwo = client.SendAsync(msgTwo).Result;
                Print(responseTwo);

                var updateItem = new Item()
                {
                    Country = "Cuba",
                    Name = "Roberto"
                };
                var msgThree = new HttpRequestMessage(new HttpMethod("PATCH"), address + "traditional/3")
                {
                    Content = new ObjectContent(typeof(Item), updateItem, new JsonMediaTypeFormatter())
                };
                var responseThree = client.SendAsync(msgThree).Result;
                Print(responseThree);

                Console.ReadLine();
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            var item = response.Content.ReadAsAsync<Item>(new[] {new JsonMediaTypeFormatter()}).Result;
            Console.WriteLine();
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Country);
        }
    }
}
