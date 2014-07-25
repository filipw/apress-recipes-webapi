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

                Console.WriteLine(client.GetStringAsync(address + "/odata/Players/Default.TopPpg()").Result);
                Console.WriteLine();

                Console.WriteLine(client.GetStringAsync(address + "/odata/Players(1)/Default.PercentageOfAllGoals()").Result);
                Console.WriteLine();

                Console.WriteLine(client.GetStringAsync(address + "/odata/TotalTeamPoints(team='Whales')").Result);
                Console.ReadLine();
            }
        }
    }
}
