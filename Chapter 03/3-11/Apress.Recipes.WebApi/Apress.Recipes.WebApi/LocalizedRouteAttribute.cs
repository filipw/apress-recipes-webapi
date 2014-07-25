using System;
using System.Collections.Generic;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class LocalizedRouteAttribute : Attribute, IDirectRouteFactory
    {
        public static Dictionary<string, Dictionary<string, string>> Routes = new Dictionary<string, Dictionary<string, string>>();

        public IEnumerable<LocalizedRouteAttribute> GetLocalizedVersions()
        {
            if (string.IsNullOrWhiteSpace(Name)) yield break;
            
            Dictionary<string, string> languageMap;
            if (Routes.TryGetValue(Name, out languageMap))
            {
                foreach (var entry in languageMap)
                {
                    yield return new LocalizedRouteAttribute(entry.Value) { Culture = entry.Key};
                }
            }
        }

        public LocalizedRouteAttribute(string template)
        {
            Template = template;
        }

        public string Culture { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public string Template { get; private set; }

        RouteEntry IDirectRouteFactory.CreateRoute(DirectRouteFactoryContext context)
        {
            var builder = context.CreateBuilder(Template);

            builder.Name = Name;
            builder.Order = Order;
            builder.DataTokens = new Dictionary<string, object>();
            builder.DataTokens["culture"] = Culture ?? "en-US";
            return builder.Build();
        }
    }
}