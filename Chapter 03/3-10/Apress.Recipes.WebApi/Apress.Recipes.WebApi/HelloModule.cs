using Nancy;

namespace Apress.Recipes.WebApi
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["page.html"] = _ => "hello nancy";
            Get["/"] = _ => "hello nancy";
        }
    }
}