using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Owin;

namespace Apress.Recipes.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Player>("Players");
            odataBuilder.EntitySet<SkaterStat>("Stats");

            var edm = odataBuilder.GetEdmModel();
            var config = new HttpConfiguration();

            config.MapODataServiceRoute("Default OData", null, edm);
            builder.UseWebApi(config);
        }
    }
}