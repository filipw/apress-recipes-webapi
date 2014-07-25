using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace Apress.Recipes.WebApi
{
    [ODataRoutePrefix("Stats")]
    public class StatsController : ODataController
    {
        private static readonly List<SkaterStat> _stats = new List<SkaterStat>
        {
            new SkaterStat
            {
                GamesPlayed = 82,
                Goals = 37,
                Assists = 43
            },
            new SkaterStat
            {
                GamesPlayed = 80,
                Goals = 30,
                Assists = 31
            },
            new SkaterStat
            {
                GamesPlayed = 78,
                Goals = 20,
                Assists = 30
            },
            new SkaterStat
            {
                GamesPlayed = 58,
                Goals = 19,
                Assists = 30
            }
        };

        [ODataRoute]
        public IQueryable<SkaterStat> GetAllStats(ODataQueryOptions queryOptions)
        {
            //assume the client sends top and skip
            var filtered = _stats.Skip(queryOptions.Skip.Value);

            if (queryOptions.Top.Value > 0)
            {
                filtered = filtered.Take(queryOptions.Top.Value);
            }

            return filtered.AsQueryable();
        }
    }
}