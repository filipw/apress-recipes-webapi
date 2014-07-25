using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var addr = "http://localhost:925/";
            using (WebApp.Start<Startup>(addr))
            {
                var clientHandler = new HttpClientHandler {Credentials = new NetworkCredential("filip", "blah")};
                var client = new HttpClient(clientHandler);
                var response = client.GetAsync(addr + "test").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine();

                //wrong identity
                var clientHandler2 = new HttpClientHandler { Credentials = new NetworkCredential("unregistereduser", "blah") };
                var client2 = new HttpClient(clientHandler2);
                var response2 = client2.GetAsync(addr + "test").Result;

                Console.WriteLine(response2);

                Console.ReadLine();
            }
        }
    }
}
