using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:900";
            var config = new HttpSelfHostConfiguration(address);
            config.MapHttpAttributeRoutes();

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Server running at {0}. Press any key to exit", address);

                var client = new HttpClient() {BaseAddress = new Uri(address)};

                var persons = client.GetAsync("person").Result;
                Console.WriteLine(persons.Content.ReadAsStringAsync().Result);

                var newPerson = new Person {Id = 3, Name = "Luiz"};
                var response = client.PostAsJsonAsync("person", newPerson).Result;

                if (response.IsSuccessStatusCode)
                {
                    var person3 = client.GetAsync("person/3").Result;
                    Console.WriteLine(person3.Content.ReadAsStringAsync().Result);
                }

                Console.ReadLine();
            }

        }
    }
}
