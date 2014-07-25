using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    public class TrackController : ApiController
    {
        public Track Post(Track track)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            }
            return track;
        }
    }
}