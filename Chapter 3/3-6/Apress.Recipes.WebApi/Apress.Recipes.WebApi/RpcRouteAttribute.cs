using System;
using System.Linq;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class RpcRouteAttribute : Attribute, IDirectRouteFactory
    {
        public RpcRouteAttribute() : this(string.Empty) {}

        public RpcRouteAttribute(string template)
        {
            Template = template;
        }

        public string Name { get; set; }

        public int Order { get; set; }

        public string Template { get; private set; }

        RouteEntry IDirectRouteFactory.CreateRoute(DirectRouteFactoryContext context)
        {
            var action = context.Actions.FirstOrDefault();
            var template = string.Format("{0}/{1}", action.ControllerDescriptor.ControllerName, action.ActionName);
            if (!string.IsNullOrWhiteSpace(Template))
            {
                template += "/" + Template;
            }
            var builder = context.CreateBuilder(template);

            builder.Name = Name;
            builder.Order = Order;
            return builder.Build();
        }
    }
}