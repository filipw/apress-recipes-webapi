using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Apress.Recipes.WebApi
{
    public static class HttpRequestMessageExtensions
    {
        public static bool IsAjaxRequest(this HttpRequestMessage request)
        {
            IEnumerable<string> headers;
            if (request.Headers.TryGetValues("X-Requested-With", out headers))
            {
                var header = headers.FirstOrDefault();
                if (!string.IsNullOrEmpty(header))
                {
                    return header.ToLowerInvariant() == "xmlhttprequest";
                }
            }

            return false;
        }
    }
}