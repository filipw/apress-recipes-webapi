using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Apress.Recipes.WebApi
{
    [HubName("trace")]
    public class TraceHub : Hub
    { }
}