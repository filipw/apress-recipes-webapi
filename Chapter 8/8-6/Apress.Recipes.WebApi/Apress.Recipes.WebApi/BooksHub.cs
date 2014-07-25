using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Apress.Recipes.WebApi
{
    [HubName("books")]
    public class BooksHub : Hub
    {
    }
}