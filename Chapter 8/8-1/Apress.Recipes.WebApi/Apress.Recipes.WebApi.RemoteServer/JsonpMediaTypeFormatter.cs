using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi.RemoteServer
{
    /// <summary>
    /// source: https://github.com/WebApiContrib/WebApiContrib.Formatting.Jsonp
    /// </summary>
    public class JsonpMediaTypeFormatter : MediaTypeFormatter
    {
        private static readonly MediaTypeHeaderValue _applicationJavaScript = new MediaTypeHeaderValue("application/javascript");
        private static readonly MediaTypeHeaderValue _applicationJsonp = new MediaTypeHeaderValue("application/json-p");
        private static readonly MediaTypeHeaderValue _textJavaScript = new MediaTypeHeaderValue("text/javascript");
        private readonly HttpRequestMessage _request;
        private readonly MediaTypeFormatter _jsonMediaTypeFormatter;
        private readonly string _callbackQueryParameter;
        private readonly string _callback;

        public JsonpMediaTypeFormatter(MediaTypeFormatter jsonMediaTypeFormatter, string callbackQueryParameter = null)
        {
            if (jsonMediaTypeFormatter == null)
            {
                throw new ArgumentNullException("jsonMediaTypeFormatter");
            }

            _jsonMediaTypeFormatter = jsonMediaTypeFormatter;
            _callbackQueryParameter = callbackQueryParameter ?? "callback";

            SupportedMediaTypes.Add(_textJavaScript);
            SupportedMediaTypes.Add(_applicationJavaScript);
            SupportedMediaTypes.Add(_applicationJsonp);
            foreach (var encoding in _jsonMediaTypeFormatter.SupportedEncodings)
            {
                SupportedEncodings.Add(encoding);
            }
                
            MediaTypeMappings.Add(new JsonpQueryStringMapping(_callbackQueryParameter, _textJavaScript));
        }

        private JsonpMediaTypeFormatter(HttpRequestMessage request, string callback, MediaTypeFormatter jsonMediaTypeFormatter, string callbackQueryParameter)
            : this(jsonMediaTypeFormatter, callbackQueryParameter)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            _request = request;
            _callback = callback;
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            string callback;
            if (IsJsonpRequest(request, _callbackQueryParameter, out callback))
            {
                return new JsonpMediaTypeFormatter(request, callback, _jsonMediaTypeFormatter, _callbackQueryParameter);
            }

            throw new InvalidOperationException("Callback missing");
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return _jsonMediaTypeFormatter.CanWriteType(type);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            var encoding = SelectCharacterEncoding(content == null ? null : content.Headers);
            using (var writer = new StreamWriter(stream, encoding, bufferSize: 4096, leaveOpen: true))
            {
                writer.Write(_callback + "(");
                writer.Flush();
                await _jsonMediaTypeFormatter.WriteToStreamAsync(type, value, stream, content, transportContext);
                writer.Write(");");
                writer.Flush();
            }
        }

        internal static bool IsJsonpRequest(HttpRequestMessage request, string callbackQueryParameter, out string callback)
        {
            callback = null;

            if (request == null || request.Method != HttpMethod.Get)
            {
                return false;
            }

            callback = request.GetQueryNameValuePairs()
                .Where(kvp => kvp.Key.Equals(callbackQueryParameter, StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value)
                .FirstOrDefault();

            return !string.IsNullOrEmpty(callback);
        }
    }
}