using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Apress.Recipes.WebApi
{
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

        [HttpGet]
        public IEnumerable<Player> TopPpg()
        {
            var result = _players.OrderByDescending(x => (double)(x.Stats.Goals + x.Stats.Assists)/(double)x.Stats.GamesPlayed).Take(3);
            return result;
        }

        [HttpGet]
        public IHttpActionResult PercentageOfAllGoals(int key)
        {
            var player = _players.FirstOrDefault(x => x.Id == key);
            if (player == null) return NotFound();

            var result = (double)player.Stats.Goals/(double)_players.Sum(x => x.Stats.Goals) * 100;
            return Ok(result);
        }

        [HttpGet]
        [ODataRoute("TotalTeamPoints(team={team})")]
        public int TotalTeamPoints([FromODataUri]string team)
        {
            var result = _players.Where(x => string.Equals(x.Team, team, StringComparison.InvariantCultureIgnoreCase))
                .Sum(x => x.Stats.Goals + x.Stats.Assists);

            return result;
        }
    }
}