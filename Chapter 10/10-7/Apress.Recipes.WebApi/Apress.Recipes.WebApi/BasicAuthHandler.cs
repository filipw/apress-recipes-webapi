using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class BasicAuthHandler : DelegatingHandler
    {
        private const string BasicAuthResponseHeaderValue = "Basic";
        private const string Realm = "Apress";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool identified = false;
            if (request.Headers.Authorization != null && string.Equals(request.Headers.Authorization.Scheme, BasicAuthResponseHeaderValue, StringComparison.CurrentCultureIgnoreCase))
            {
                var credentials =
                    Encoding.UTF8.GetString(Convert.FromBase64String(request.Headers.Authorization.Parameter));
                var user = credentials.Split(':')[0].Trim();
                var pwd = credentials.Split(':')[1].Trim();
                //validate username and password here and set identified

                if (user == "filip")
                {
                    identified = true;
                }

                if (identified)
                {
                    var id = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, user)}, BasicAuthResponseHeaderValue);
                    var principal = new ClaimsPrincipal(new[] {id});
                    request.GetRequestContext().Principal = principal;
                }
            }

            if (!identified)
            {
                var unauthorizedResponse = request.CreateResponse(HttpStatusCode.Unauthorized);
                unauthorizedResponse.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(BasicAuthResponseHeaderValue, Realm));
                return Task.FromResult(unauthorizedResponse);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
