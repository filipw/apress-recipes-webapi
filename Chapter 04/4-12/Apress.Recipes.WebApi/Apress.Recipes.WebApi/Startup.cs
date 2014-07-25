using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Owin;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IHostBufferPolicySelector), new FileUploadBufferPolicySelector(new OwinBufferPolicySelector()));

            appBuilder.UseWebApi(config);
        }
    }
}