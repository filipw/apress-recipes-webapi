using System;
using System.Net;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace Apress.Recipes.WebApi.RemoteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:9000/";

            using (WebApp.Start<Startup>(address))
            {
                Console.WriteLine("Server is running at {0}", address);
                Console.ReadLine();
            }
        }
    }
}
