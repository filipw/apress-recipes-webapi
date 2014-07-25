using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
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
                var client = new HttpClient();
                var batchContent = new MultipartContent("mixed")
                {
                    new HttpMessageContent(new HttpRequestMessage(HttpMethod.Post, address + "/api/items")
                    {
                        Content = new ObjectContent(typeof (Item),
                                new Item {Country = "Switzerland", Id = 1, Name = "Filip"},
                                new JsonMediaTypeFormatter())
                    }),

                    new HttpMessageContent(new HttpRequestMessage(HttpMethod.Post, address + "/api/items")
                    {
                        Content =
                            new ObjectContent(typeof (Item), new Item {Country = "Canada", Id = 2, Name = "Felix"},
                                new JsonMediaTypeFormatter())
                    }),

                    new HttpMessageContent(new HttpRequestMessage(HttpMethod.Get, address + "/api/items"))
                };

                var batchRequest = new HttpRequestMessage(HttpMethod.Post, address + "/api/batch")
                {
                    Content = batchContent
                };

                var batchResponse = client.SendAsync(batchRequest).Result;

                var streamProvider = batchResponse.Content.ReadAsMultipartAsync().Result;
                foreach (var content in streamProvider.Contents)
                {
                    var response = content.ReadAsHttpResponseMessageAsync().Result;
                    Print(response);
                }

                Console.ReadLine();
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            Console.WriteLine(response);
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                var item = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
