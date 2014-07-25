using System.Net;
using System.Web.Http;
using Owin;

namespace Apress.Recipes.WebApi.OwinSelfHost
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var listener = app.Properties["System.Net.HttpListener"] as HttpListener;
            if (listener != null)
            {
                listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
            }

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}