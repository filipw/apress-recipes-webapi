using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace Apress.Recipes.WebApi.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "http://localhost:925/";

            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();

                var response = client.GetAsync(address + "files/test.html").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                var response2 = client.GetAsync(address + "razor/item").Result;
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);


                Console.ReadLine(); 
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "Razor", "razor/item",
                new { controller = "Razor" });

            config.Routes.MapHttpRoute(
                "HTML", "files/{filename}",
                new { controller = "Html" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HtmlController : ApiController
    {
        public HttpResponseMessage Get(string filename)
        {
            var response = new HttpResponseMessage
            {
                Content =
                    new StreamContent(File.Open(AppDomain.CurrentDomain.BaseDirectory + "/files/" + filename,
                        FileMode.Open))
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }

    public class RazorController : ApiController
    {
        public IHttpActionResult Get()
        {
            return new HtmlActionResult("Item", new Item { Id = 1, Name = "Filip"});
        }
    }

    public class HtmlActionResult : IHttpActionResult
    {
        private readonly string _view;
        private readonly dynamic _model;

        public HtmlActionResult(string viewName, dynamic model)
        {
            _view = LoadView(viewName);
            _model = model;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var parsedView = RazorEngine.Razor.Parse(_view, _model);
            response.Content = new StringContent(parsedView);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return Task.FromResult(response);
        }

        private static string LoadView(string name)
        {
            var view = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "views", name + ".cshtml"));
            return view;
        }
    }

}
