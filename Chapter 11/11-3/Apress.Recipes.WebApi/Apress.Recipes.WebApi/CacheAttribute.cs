using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class CacheAttribute : ActionFilterAttribute
    {
        public int ClientTimeSpan { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response.StatusCode >= HttpStatusCode.InternalServerError)
            {
                return;
            }

            var cachecontrol = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(ClientTimeSpan),
                MustRevalidate = true,
                Public = true
            };

            actionExecutedContext.Response.Headers.CacheControl = cachecontrol;
        }
    }
}
