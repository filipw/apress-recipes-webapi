using System;
using System.Web.Http.Controllers;

namespace Apress.Recipes.WebApi
{
    public class SampleAttribute : OrderedActionFilterAttribute
    {
        public string Scope { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("Should be executed at position {0}, {1}", Order, Scope);
        }
    }
}