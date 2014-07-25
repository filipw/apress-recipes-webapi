using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class VersionedRouteAttribute : RouteFactoryAttribute
    {
        public VersionedRouteAttribute(string template) : base(template)
        {
            Order = -1;
        }

        public int Version { get; set; }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                return new HttpRouteValueDictionary
                {
                    {"", new VersionConstraint(Version)}
                };
            }
        }
    }

    
}