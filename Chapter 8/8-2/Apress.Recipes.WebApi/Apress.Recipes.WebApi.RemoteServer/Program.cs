using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

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

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            appBuilder.UseWebApi(config);
        }
    }
}
