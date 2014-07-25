using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Nancy;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            //config.Routes.IgnoreRoute("Home", "{whatever}.html/{*pathInfo}");
            config.Routes.MapHttpRoute("Home", "{whatever}.html/{*pathInfo}", null, null, new StopRoutingHandler());
            //config.Routes.IgnoreRoute("FilesRoute", "files/{*pathInfo}");
            config.Routes.MapHttpRoute("FilesRoute", "files/{*pathInfo}", null, null, new StopRoutingHandler());
            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
            appBuilder.UseFileServer(new FileServerOptions()
            {
                RequestPath = new PathString("/files"),
                EnableDirectoryBrowsing = true
            });
            appBuilder.UseNancy();
        }
    }

    //public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    //{
    //    protected override IReadOnlyCollection<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
    //    {
    //        return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
    //    }
    //}

    //public abstract class BaseApiController : ApiController
    //{
    //    [Route("{id}")]
    //    public string Get(int id)
    //    {
    //        return "Value:" + id;
    //    }
    //}

    //[RoutePrefix("api/test")]
    //public class TestController : BaseApiController
    //{

    //}

    public class TestController : ApiController
    {
        //[Route("test")]
        public IEnumerable<string> Get()
        {
            return new[] { "hello", "world" };
        }

        public string Get(int id)
        {
            return "hello world";
        }
    }

    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["page.html"] = _ => "hello nancy";
            Get["/"] = _ => "hello nancy";
        }
    }
}