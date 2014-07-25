using System.Globalization;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("email", typeof(EmailRouteConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
                name: "Email",
                routeTemplate: "{controller}/email/{text}",
                constraints: new { text = new EmailRouteConstraint() },
                defaults: null
            );

            config.Routes.MapHttpRoute(
                name: "Alpha",
                routeTemplate: "{controller}/alpha/{text}",
                constraints: new { text = new AlphaRouteConstraint() },
                defaults: null
            );

            appBuilder.UseWebApi(config);
        }
    }
}