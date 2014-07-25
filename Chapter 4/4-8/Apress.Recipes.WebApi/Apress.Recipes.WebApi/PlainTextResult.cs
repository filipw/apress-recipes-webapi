using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class PlainTextResult : IHttpActionResult
    {
        private readonly string _text;
        private readonly Encoding _encoding;

        public PlainTextResult(string text, Encoding encoding)
        {
            _text = text;
            _encoding = encoding;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_text, _encoding)
            };

            return Task.FromResult(response);
        }
    }
}