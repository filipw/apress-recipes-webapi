using System;
using System.Net.Http;
using WebApiContrib.Caching;
using WebApiContrib.MessageHandlers;

namespace Apress.Recipes.WebApi
{
    public class OwinCompatibleThrottlingHandler : ThrottlingHandler
    {
        public OwinCompatibleThrottlingHandler(IThrottleStore store, Func<string, long> maxRequestsForUserIdentifier, TimeSpan period, string message)
            : base(store, maxRequestsForUserIdentifier, period, message)
        {

        }

        //override added to support OWIN, as at the time of writing, ThrottlingHandler did not support OWIN host
        protected override string GetUserIdentifier(HttpRequestMessage request)
        {
            var id = request.GetClientIpAddress();
            return id;
        }
    }
}