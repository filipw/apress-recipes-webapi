using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi.SelfHost
{
    public class HtmlActionResult : IHttpActionResult
    {
        private readonly string _view;
        private readonly dynamic _model;

        public HtmlActionResult(string viewName, dynamic model)
        {
            _view = LoadView(viewName);
            _model = model;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var parsedView = RazorEngine.Razor.Parse(_view, _model);
            response.Content = new StringContent(parsedView);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return Task.FromResult(response);
        }

        private static string LoadView(string name)
        {
            var view = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "views", name + ".cshtml"));
            return view;
        }
    }
}