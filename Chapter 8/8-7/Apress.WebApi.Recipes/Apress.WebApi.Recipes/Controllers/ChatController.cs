using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Apress.WebApi.Recipes.Models;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;

namespace Apress.WebApi.Recipes.Controllers
{
    [Route("chat/{username:alpha}")]
    public class ChatController : ApiController
    {
        public HttpResponseMessage Get(string username)
        {
            var httpcontext = Request.Properties["MS_HttpContext"] as HttpContextBase;
            if (httpcontext == null) return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            httpcontext.AcceptWebSocketRequest(new ChatHandler(username));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

        public void Post(Message msg)
        {
            ChatHandler.ChatClients.Broadcast(JsonConvert.SerializeObject(msg));
        }
    }
}