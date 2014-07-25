using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class CacheAttributeTests
    {

        [Fact]
        public void WhenActionErrorsOutShouldNotCache()
        {
            var attribute = new CacheAttribute();
            var executedContext = new HttpActionExecutedContext(new HttpActionContext
            {
                Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            }, null);
            
            attribute.OnActionExecuted(executedContext);

            Assert.Null(executedContext.Response.Headers.CacheControl);
        }

        [Fact]
        public void WhenActionIsSuccessfulRelevantCacheControlIsSet()
        {
            var attribute = new CacheAttribute {ClientTimeSpan = 100};
            var executedContext = new HttpActionExecutedContext(new HttpActionContext
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK)
            }, null);

            attribute.OnActionExecuted(executedContext);

            Assert.Equal(TimeSpan.FromSeconds(100), executedContext.Response.Headers.CacheControl.MaxAge);
            Assert.Equal(true, executedContext.Response.Headers.CacheControl.Public);
            Assert.Equal(true, executedContext.Response.Headers.CacheControl.MustRevalidate);
        }

    }
}