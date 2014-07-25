using System;
using System.Net.Http;
using System.Web.Http.Hosting;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            var address = "http://localhost:920/";

            using (WebApp.Start<Startup>(url: address))
            {
                var client = new HttpClient();

                var response = client.GetAsync(address + "test").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
