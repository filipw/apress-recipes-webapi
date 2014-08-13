using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Http.SelfHost;
using System.Web.Http.SelfHost.Channels;

namespace Apress.Recipes.WebApi.SelfHost
{
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