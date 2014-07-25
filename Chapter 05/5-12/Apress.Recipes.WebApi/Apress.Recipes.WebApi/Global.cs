using System.Collections.Concurrent;

namespace Apress.Recipes.WebApi
{
    public static class Global
    {
        static Global()
        {
            Storage = new ConcurrentDictionary<string, object>();
        }

        public static ConcurrentDictionary<string, object> Storage { get; set; }
    }
}