using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using apressrecipesService.DataObjects;
using apressrecipesService.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace apressrecipesService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class TodoItemController : TableController<TodoItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            apressrecipesContext context = new apressrecipesContext();
            DomainManager = new EntityDomainManager<TodoItem>(context, Request, Services);
        }

        [AuthorizeLevel(AuthorizationLevel.User)]
        public IQueryable<TodoItem> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TodoItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        {
            TodoItem current = await InsertAsync(item);
            var message = new GooglePushMessage(new Dictionary<string, string> {{"message", "Hello from Web API!"}},
                TimeSpan.FromDays(1));
            
            var result = await Services.Push.SendAsync(message);
            Services.Log.Info(result.State.ToString());

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}