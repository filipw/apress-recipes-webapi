using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace Apress.Recipes.WebApi.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var addr = "http://localhost:925";
            var config = new HttpSelfHostConfiguration(addr)
            {
                ClientCredentialType = HttpClientCredentialType.Windows
            };
            config.MapHttpAttributeRoutes();

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();


                var client = new HttpClient(new HttpClientHandler {UseDefaultCredentials = true});
                var result = client.GetAsync(addr + "/test").Result;
                Console.WriteLine(result.StatusCode);
                Console.WriteLine(result.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }

    public class WindowsAuthSelfHostConfiguration : HttpSelfHostConfiguration
    {
        public WindowsAuthSelfHostConfiguration(string baseAddress)
            : base(baseAddress)
        { }

        protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
        {
            httpBinding.Security.Mode = HttpBindingSecurityMode.TransportCredentialOnly;
            httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            return base.OnConfigureBinding(httpBinding);
        }
    }
}
