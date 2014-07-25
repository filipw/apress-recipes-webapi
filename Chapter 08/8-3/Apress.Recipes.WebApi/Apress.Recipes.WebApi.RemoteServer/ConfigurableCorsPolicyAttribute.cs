using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Apress.Recipes.WebApi.RemoteServer
{
    public class ConfigurableCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        public ConfigurableCorsPolicyAttribute(string name)
        {
            _policy = new CorsPolicy();

            var corsConfig = ConfigurationManager.GetSection("cors") as CorsSection;
            if (corsConfig != null)
            {
                var policy = corsConfig.CorsPolicies.Cast<CorsElement>().FirstOrDefault(x => x.Name == name);
                if (policy != null)
                {
                    if (policy.Headers == "*")
                    {
                        _policy.AllowAnyHeader = true;
                    }
                    else
                    {
                        policy.Headers.Split(';').ToList().ForEach(x => _policy.Headers.Add(x));
                    }

                    if (policy.Methods == "*")
                    {
                        _policy.AllowAnyMethod = true;
                    }
                    else
                    {
                        policy.Methods.Split(';').ToList().ForEach(x => _policy.Methods.Add(x));
                    }

                    if (policy.Origins == "*")
                    {
                        _policy.AllowAnyOrigin = true;
                    }
                    else
                    {
                        policy.Origins.Split(';').ToList().ForEach(x => _policy.Origins.Add(x));
                    }
                }
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}