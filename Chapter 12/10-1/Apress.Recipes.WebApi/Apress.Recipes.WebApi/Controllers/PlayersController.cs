using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Apress.Recipes.WebApi.Models.Apress.Recipes.WebApi;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Player>("Players");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PlayersController : ODataController
    {
        private PlayersAppContext db = new PlayersAppContext();

        // GET: odata/Players
        [Queryable]
        public IQueryable<Player> GetPlayers()
        {
            return db.Players;
        }

        // GET: odata/Players(5)
        [Queryable]
        public SingleResult<Player> GetPlayer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Players.Where(player => player.Id == key));
        }

        // PUT: odata/Players(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != player.Id)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(player);
        }

        // POST: odata/Players
        public async Task<IHttpActionResult> Post(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            await db.SaveChangesAsync();

            return Created(player);
        }

        // PATCH: odata/Players(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Player> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = await db.Players.FindAsync(key);
            if (player == null)
            {
                return NotFound();
            }

            patch.Patch(player);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(player);
        }

        // DELETE: odata/Players(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Player player = await db.Players.FindAsync(key);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int key)
        {
            return db.Players.Count(e => e.Id == key) > 0;
        }
    }
}
