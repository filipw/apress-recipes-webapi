using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:925";
            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                //ask for full metadata in the response and only players from team "Whales"
                Console.WriteLine(client.GetStringAsync(address + "/Players?$format=application/json;odata.metadata=full&$filter=Team eq 'Whales'").Result);
                Console.WriteLine();

                //only the Name of the Player with key = 1
                Console.WriteLine(client.GetStringAsync(address + "/Players(1)?$select=Name").Result);
                Console.WriteLine();

                //skip first Stat and take next two, will be parsed manually in the controller
                Console.WriteLine(client.GetStringAsync(address + "/Stats?$skip=1&$top=2").Result);
                Console.ReadLine();
            }
        }
    }
}
