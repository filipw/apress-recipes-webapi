using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main()
        {
            var address = "http://localhost:920/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var team = new Team {Id = 3, Name = "Los Angeles Kings"};
                var team2 = new Team { Name = "Boston Bruins" };
                var player = new Player {Name = "Tyler Bozak", Team = 1};

                Send(HttpMethod.Get, client, address + "api/teams");
                Send(HttpMethod.Get, client, address + "api/teams/1");
                Send(HttpMethod.Get, client, address + "api/teams/1/players");

                Console.WriteLine(client.PostAsJsonAsync(address+"api/teams", team).Result.StatusCode);
                Console.WriteLine();

                Console.WriteLine(client.PostAsJsonAsync(address+"api/teams/1/players", player).Result.StatusCode);
                Console.WriteLine();

                Console.WriteLine(client.PutAsJsonAsync(address + "api/teams/2", team2).Result.StatusCode);
                Console.WriteLine();

                Send(HttpMethod.Get, client, address + "api/teams");
                Send(HttpMethod.Get, client, address + "api/teams/1/players");
            }

            Console.ReadLine();
        }

        private static void Send(HttpMethod method, HttpClient client, string url)
        {
            var msg = new HttpRequestMessage(method, url);
            var response = client.SendAsync(msg).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine(response.StatusCode);

            Console.WriteLine();
        }
    }
}
