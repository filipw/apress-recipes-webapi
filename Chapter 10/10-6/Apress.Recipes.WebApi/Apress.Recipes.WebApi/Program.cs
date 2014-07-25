using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var addr = "http://localhost:925/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(addr))
            {
                var client = new HttpClient();
                var response = client.GetAsync(addr + "test").Result;
                Console.WriteLine(response);

                Console.WriteLine();

                var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("filipClient:secretKey"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

                var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", "filip"},
                    {"password", "xxx"},
                };

                var tokenResponse = client.PostAsync(addr + "accesstoken", new FormUrlEncodedContent(form)).Result;
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                
                Console.WriteLine("Token issued is: {0}", token.AccessToken);

                Console.WriteLine();
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var authorizedResponse = client.GetAsync(addr + "test").Result;
                Console.WriteLine(authorizedResponse);
                Console.WriteLine(authorizedResponse.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}
