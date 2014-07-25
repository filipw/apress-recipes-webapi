using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var myService = actionContext.Request.GetDependencyScope().GetService(typeof(IService)) as IService;
            if (myService != null)
            {
                Debug.WriteLine(myService.SaySomething("Something from action executing"));
            }
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var myService = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IService)) as IService;
            if (myService != null)
            {
                Debug.WriteLine(myService.SaySomething("Something from action executed"));
            }
        }
    }
}