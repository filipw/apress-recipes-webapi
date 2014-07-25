using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using HawkNet;
using HawkNet.WebApi;

namespace Apress.Recipes.WebApi
{
    internal class Program
    {
        private static void Main()
        {
            const string address = "http://localhost:925/";

            var config = new HttpSelfHostConfiguration(address);
            config.MapHttpAttributeRoutes();
            var handler = new HawkMessageHandler(
                async id => new HawkCredential
                {
                    Id = id,
                    Key = "abcdefghijkl",
                    Algorithm = "sha256",
                    User = "filip"
                }, 4, true);

            config.MessageHandlers.Add(handler);

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                var client = new HttpClient();

                //this will fail
                var request = new HttpRequestMessage(HttpMethod.Get, address + "test");
                var response = client.SendAsync(request).Result;
                Console.WriteLine(response.StatusCode);
                Console.WriteLine();

                var credential = new HawkCredential
                {
                    Id = "this-is-my-id",
                    Key = "abcdefghijkl",
                    Algorithm = "sha256",
                    User = "filip"
                };

                var clientHandler = new HawkClientMessageHandler(new HttpClientHandler(), credential, ts: DateTime.Now);
                var client2 = new HttpClient(clientHandler);

                //this will succeed
                request = new HttpRequestMessage(HttpMethod.Get, address + "test");
                var response2 = client2.SendAsync(request).Result;
                Console.WriteLine(response2.StatusCode);
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                Console.WriteLine("Sleeping to get outside of the timestamp window. Next request will fail - replay protection.");
                Thread.Sleep(5000);

                //this will fail
                request = new HttpRequestMessage(HttpMethod.Get, address + "test");
                var response3 = client2.SendAsync(request).Result;
                Console.WriteLine(response3.StatusCode);
                Console.WriteLine();

                Console.ReadLine();
            }
        }
    }
}
