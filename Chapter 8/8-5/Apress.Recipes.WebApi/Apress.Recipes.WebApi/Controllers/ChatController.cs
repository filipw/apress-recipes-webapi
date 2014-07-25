using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Apress.Recipes.WebApi.Models;
using Newtonsoft.Json;

namespace Apress.Recipes.WebApi.Controllers
{
    public class ChatController : ApiController
    {
        private static object locker = new object();
        
        private static readonly List<StreamWriter> Subscribers = new List<StreamWriter>();

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var response = new HttpResponseMessage
            {
                Content = new PushStreamContent(async (respStream, content, context) =>
                {
                    var subscriber = new StreamWriter(respStream)
                    {
                        AutoFlush = true
                    };
                    lock (locker)
                    {
                        Subscribers.Add(subscriber);
                    }
                    await subscriber.WriteLineAsync("data: \n");
                }, "text/event-stream")
            };
            return response;
        }

        public async Task Post(Message m)
        {
            m.DateTime = DateTime.Now;
            await MessageCallback(m);
        }

        private static async Task MessageCallback(Message m)
        {
            for (var i = Subscribers.Count - 1; i >= 0; i--)
            {
                try
                {
                    await Subscribers[i].WriteLineAsync("data:" + JsonConvert.SerializeObject(m) + "\n");
                    await Subscribers[i].WriteLineAsync("");
                    await Subscribers[i].FlushAsync();
                }
                catch (Exception)
                {
                    lock (locker)
                    {
                        Subscribers.RemoveAt(i);
                    }
                }
            }
        }
    }
}
