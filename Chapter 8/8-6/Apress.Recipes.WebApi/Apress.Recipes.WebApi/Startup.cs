using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}