using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Apress.Recipes.WebApi
{
    [ODataRoutePrefix("Players")]
    public class PlayersController : ODataController
    {
        private static List<Player> _players = new List<Player>
        {
            new Player
            {
                Id = 1,
                Name = "Filip",
                Team = "Whales",
                Stats = new SkaterStat
                {
                    GamesPlayed = 82, Goals = 37, Assists = 43
                }
            },
            new Player
            {
                Id = 2,
                Name = "Felix",
                Team = "Whales",
                Stats = new SkaterStat
                {
                    GamesPlayed = 80, Goals = 30, Assists = 31
                }
            },
            new Player
            {
                Id = 3,
                Name = "Luiz",
                Team = "Dolphins",
                Stats = new SkaterStat
                {
                    GamesPlayed = 78, Goals = 20, Assists = 30
                }
            },
            new Player
            {
                Id = 4,
                Name = "Terry",
                Team = "Dolphins",
                Stats = new SkaterStat
                {
                    GamesPlayed = 58, Goals = 19, Assists = 30
                }
            }
        };

        [EnableQuery]
        [ODataRoute]
        public IQueryable<Player> GetAllPlayers()
        {
            return _players.AsQueryable();
        }

        [EnableQuery]
        [ODataRoute("({key})")]
        public SingleResult<Player> GetSinglePlayers(int key)
        {
            return SingleResult.Create(_players.Where(x => x.Id == key).AsQueryable());
        }
    }
}