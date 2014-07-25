using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

                var req1 = new HttpRequestMessage(HttpMethod.Get, address + "order/1");
                var res1 = client.SendAsync(req1).Result;
                Console.WriteLine(req1.RequestUri);
                Console.WriteLine(res1.Content.ReadAsStringAsync().Result);

                Console.WriteLine();

                var req2 = new HttpRequestMessage(HttpMethod.Get, address + "auftrag/1");
                var res2 = client.SendAsync(req2).Result;
                Console.WriteLine(req2.RequestUri);
                Console.WriteLine(res2.Content.ReadAsStringAsync().Result);

                Console.WriteLine();

                var req3 = new HttpRequestMessage(HttpMethod.Get, address + "zamowienie/1");
                var res3 = client.SendAsync(req3).Result;
                Console.WriteLine(req3.RequestUri);
                Console.WriteLine(res3.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }

    }
}
