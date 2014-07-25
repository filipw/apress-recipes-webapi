using System;
using System.Net.Http;
using System.Text;
using System.Web.Http.Tracing;
using Microsoft.AspNet.SignalR;

namespace Apress.Recipes.WebApi
{
    public class SignalRTraceWrapper : ITraceWriter
    {
        private readonly ITraceWriter _traceWriter;
        private readonly Lazy<IHubContext> _hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext(_hubname));
        private static string _hubname = "trace";

        public SignalRTraceWrapper(ITraceWriter traceWriter, string hubname)
        {
            _traceWriter = traceWriter;
            _hubname = hubname;
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                var record = new TraceRecord(request, category, level);
                traceAction(record);

                if (!string.IsNullOrWhiteSpace(_hubname))
                    _hub.Value.Clients.All.logMessage(ComposeMessage(record));

                _traceWriter.Trace(request, category, level, traceAction);
            }

        }

        public static void Enable(string hubname)
        {
            _hubname = hubname;
        }

        public static void Disable()
        {
            _hubname = null;
        }


        private static string ComposeMessage(TraceRecord record)
        {
            var message = new StringBuilder();

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append(record.Request.Method);

                if (record.Request.RequestUri != null)
                    message.Append(" ").Append(record.Request.RequestUri.AbsoluteUri);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append(" ").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append(" ").Append(record.Message);

            if (record.Exception != null && !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
                message.Append(" ").Append(record.Exception.GetBaseException().Message);

            return message.ToString();
        }

    }
}