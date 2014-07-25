using System;
using System.Net.Http;

namespace Apress.Recipes.WebApi
{
    public static class HttpRequestMessageExtensions
    {
        public static void Add(this HttpRequestMessage request, string key, object o)
        {
            request.Properties.Add(key, o);
        }

        public static T Get<T>(this HttpRequestMessage request, string key)
        {
            object result;
            if (request.Properties.TryGetValue(key, out result))
            {
                if (result is T)
                {
                    return (T) result;
                }
                try
                {
                    return (T)Convert.ChangeType(result, typeof (T));
                }
                catch (InvalidCastException) {}
            }

            return default(T);
        }
    }
}