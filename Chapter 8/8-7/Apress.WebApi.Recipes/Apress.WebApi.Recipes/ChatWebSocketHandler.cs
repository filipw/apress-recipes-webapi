using System;
using Apress.WebApi.Recipes.Models;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;

namespace Apress.WebApi.Recipes
{
    public  class ChatHandler : WebSocketHandler
    {
        private static readonly object Locker = new object();
        public static WebSocketCollection ChatClients = new WebSocketCollection();
        private readonly string _username;

        public ChatHandler(string username)
        {
            _username = username;
        }

        public override void OnOpen()
        {
            lock (Locker)
                ChatClients.Add(this); 
        }

        public override void OnMessage(string message)
        {
            var msg = JsonConvert.DeserializeObject<Message>(message);
            msg.DateTime = DateTime.Now;
            msg.Username = _username;

            ChatClients.Broadcast(JsonConvert.SerializeObject(msg));
        }

        public override void OnClose()
        {
            lock (Locker)
                ChatClients.Remove(this);
        }
    }
}
