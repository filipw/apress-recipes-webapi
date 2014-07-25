using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class ThirdAttribute : ActionFilterAttribute
    {
        public string Scope { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("Should be executed third, {0}", Scope);
        }
    }
}