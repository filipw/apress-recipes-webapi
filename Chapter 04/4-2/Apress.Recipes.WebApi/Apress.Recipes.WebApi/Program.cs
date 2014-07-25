using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Owin.Hosting;
using WebApiContrib.Formatting;

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

                var meesage = new HttpRequestMessage(HttpMethod.Get, address + "items");
                meesage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
                var response = client.SendAsync(meesage).Result;
                
                var deserialized = response.Content.ReadAsAsync<IEnumerable<Item>>(new[] {new ProtoBufFormatter() }).Result;

                foreach (var item in deserialized)
                {
                    Console.WriteLine("{0} {1}", item.Id, item.Name);
                }
            }

            Console.ReadLine();
        } 
    }
}
