using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class FirstAttribute : ActionFilterAttribute
    {
        public string Scope { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("Should be executed first, {0}", Scope);
        }
    }
}