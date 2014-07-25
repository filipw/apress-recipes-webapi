using System;
using System.Net.Http;
using System.Web.Http.Filters;
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

                var response = client.GetAsync(address + "api/test").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }

    //note: the scope property is not necessary here - it's just so that we can print out what is the current scope of the filter
}
