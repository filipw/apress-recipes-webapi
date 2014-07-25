using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Apress.Recipes.WebApi
{
    public class SampleHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var scope = request.GetDependencyScope();
            var service = scope.GetService(typeof (IService)) as IService;
            if (service != null)
            {
                Debug.WriteLine(service.SaySomething());
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}