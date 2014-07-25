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
            var player = odataBuilder.EntityType<Player>();

            //collection function
            player.Collection.Function("TopPpg").ReturnsCollection<Player>();

            //entity function
            player.Function("PercentageOfAllGoals").Returns<double>();

            //service function
            var serviceFunc = odataBuilder.Function("TotalTeamPoints");
            serviceFunc.Returns<int>().Parameter<string>("team");
            serviceFunc.IncludeInServiceDocument = true;

            var edm = odataBuilder.GetEdmModel();

            var config = new HttpConfiguration();
            config.MapODataServiceRoute("Default OData", "odata", edm);
            builder.UseWebApi(config);
        }
    }
}