using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi.OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var addr = "http://localhost:925";

            using (WebApp.Start<Startup>(addr))
            {
                var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
                var result = client.GetAsync(addr + "/test").Result;
                Console.WriteLine(result.StatusCode);
                Console.WriteLine(result.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
