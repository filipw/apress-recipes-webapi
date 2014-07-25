using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apress.Recipes.WebApi.Startup))]
namespace Apress.Recipes.WebApi
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
