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
                var client = new HttpClient();
                var msgv1 = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                var responsev1 = client.SendAsync(msgv1).Result;
                Print(responsev1);

                var msgv2 = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                msgv2.Headers.Add("ApiVersion", "2");
                var responsev2 = client.SendAsync(msgv2).Result;
                Print(responsev2);

                var msgv1ContentType = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                msgv1ContentType.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.apress.recipes.webapi+json"));
                var responsev1ContentType = client.SendAsync(msgv1ContentType).Result;
                Print(responsev1ContentType);

                var msgv2ContentType = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                msgv2ContentType.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.apress.recipes.webapi-v2+json"));
                var responsev2ContentType = client.SendAsync(msgv2ContentType).Result;
                Print(responsev2ContentType);

                var msgUriVersion = new HttpRequestMessage(HttpMethod.Get, address + "items/1");
                var responseUriVersion = client.SendAsync(msgUriVersion).Result;
                Print(responseUriVersion);

                var msgUriVersion2 = new HttpRequestMessage(HttpMethod.Get, address + "v2/items/1");
                var responseUriVersion2 = client.SendAsync(msgUriVersion2).Result;
                Print(responseUriVersion2);

                Console.ReadLine();
            }
        }

        private static void Print(HttpResponseMessage response)
        {
            var item = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
