using System.Net;
using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
        //    HttpListener listener =
        //(HttpListener)appBuilder.Properties["System.Net.HttpListener"];
        //    listener.AuthenticationSchemes =
        //    AuthenticationSchemes.IntegratedWindowsAuthentication;

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new RequireHttpsAttribute());

            appBuilder.UseWebApi(config);
        }
    }
}