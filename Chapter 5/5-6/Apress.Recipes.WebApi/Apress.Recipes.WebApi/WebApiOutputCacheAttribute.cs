using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class CacheAttribute : ActionFilterAttribute
    {
        private string _cachekey;
        private static readonly ObjectCache Cache = MemoryCache.Default;

        public int Server { get; set; }

        public int Client { get; set; }

        public bool AnonymousOnly { get; set; }

        private bool IsCacheable(int property, HttpActionContext ac)
        {
            if (property <= 0)
            {
                return false;
            }
            
            if (AnonymousOnly && ac.RequestContext.Principal.Identity.IsAuthenticated)
                return false;

            if (ac.Request.Method == HttpMethod.Get)
                return true;

            return false;
        }

        private CacheControlHeaderValue GetClientCache()
        {
            var cachecontrol = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(Client),
                MustRevalidate = true
            };

            return cachecontrol;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (IsCacheable(Server, actionContext))
            {
                var accept = actionContext.Request.Headers.Accept.FirstOrDefault() ?? new MediaTypeHeaderValue("application/json");
                _cachekey = string.Format("{0}|{1}", actionContext.Request.RequestUri.PathAndQuery, accept);

                var cachedResponseContent = Cache.Get(_cachekey) as WebApiCacheItem;
                if (cachedResponseContent == null || !cachedResponseContent.IsValid()) return;

                actionContext.Response = actionContext.Request.CreateResponse();
                actionContext.Response.Content = new ByteArrayContent(cachedResponseContent.Content);
                actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue(cachedResponseContent.ContentType);

                if (IsCacheable(Client, actionContext))
                {
                    actionContext.Response.Headers.CacheControl = GetClientCache();
                }
            }
        }

        public async override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (!Cache.Contains(_cachekey))
            {
                var body = await actionExecutedContext.Response.Content.ReadAsByteArrayAsync();
                var cacheItem = new WebApiCacheItem(actionExecutedContext.Response.Content.Headers.ContentType, body);
                Cache.Add(_cachekey, cacheItem, DateTime.Now.AddSeconds(Server));
            }

            if (IsCacheable(Client, actionExecutedContext.ActionContext))
            {
                actionExecutedContext.ActionContext.Response.Headers.CacheControl = GetClientCache();   
            }
        }
    }
}