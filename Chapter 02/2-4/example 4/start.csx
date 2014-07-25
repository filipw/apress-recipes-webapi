using Microsoft.Owin.Hosting;
using System.Net.Http;
using Owin; 
using System.Web.Http; 

public class TestController : ApiController {
	public string Get() { return "Hello scriptcs!";}
}

 public class Startup 
    { 
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder) 
        { 
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration(); 
            config.Routes.MapHttpRoute( 
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}", 
                defaults: new { id = RouteParameter.Optional } 
            ); 

            appBuilder.UseWebApi(config); 
        } 
    } 

/*var options = new StartOptions
        {
            ServerFactory = "Nowin",
            Port = 8080
        };

        using (WebApp.Start<Startup>(options))
        {
            Console.WriteLine("Running a http server on port 8080");
            Console.ReadKey();
        }*/

                    string baseAddress = "http://localhost:9000/"; 

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress)) 
            { 
                Console.ReadKey();
            } 