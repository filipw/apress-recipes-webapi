using System;
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

        [Route("api/teams/{id}", Name = "GetTeamById")]
        public Team GetTeam(int id)
        {
            var team = Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return team;
        }

        [Route("api/teams")]
        public HttpResponseMessage PostTeam(Team team)
        {
            Teams.Add(team);
            var routeLink = Url.Link("GetTeamById", new {id = team.Id});
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            response.Headers.Location = new Uri(routeLink);
            return response;
        }
    }
}