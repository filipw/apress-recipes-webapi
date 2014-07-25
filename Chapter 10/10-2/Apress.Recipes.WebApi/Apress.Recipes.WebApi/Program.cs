using System;
using System.Net;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslErrors) => true;

            var address = "https://localhost:4443/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var response = client.GetAsync(address + "test").Result;
                Console.WriteLine(response.StatusCode);

                Console.ReadLine();
            }
        }
    }
}
