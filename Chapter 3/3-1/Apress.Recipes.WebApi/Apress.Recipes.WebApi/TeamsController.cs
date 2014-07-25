using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TeamsController : ApiController
    {
        private static readonly List<Team> Teams = new List<Team>
            {
                new Team {Id = 1, Name = "Toronto Maple Leafs"},
                new Team {Id = 2, Name = "Montreal Canadiens"}
            };

        private static readonly List<Player> Players = new List<Player>
            {
                new Player { Team = 1, Name = "Dion Phaneuf"},
                new Player { Team = 1, Name = "Phil Kessel"}
            };

        public Team GetTeam(int id)
        {
            var team = Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return team;
        }

        public IEnumerable<Team> GetTeams()
        {
            return Teams;
        }

        public IEnumerable<Player> GetPlayers(int teamId)
        {
            var players = Players.Where(x => x.Team == teamId);
            if (players == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return players;
        }
    }
}