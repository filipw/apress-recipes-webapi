using System.Linq;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Owin;
using Microsoft.Owin;

namespace Apress.Recipes.WebApi
{
    public class FileUploadBufferPolicySelector : IHostBufferPolicySelector
    {
        private readonly OwinBufferPolicySelector _owinBufferPolicySelector;
        private static readonly string[] UnbufferedControllers = {"unbuffered"};

        public FileUploadBufferPolicySelector(OwinBufferPolicySelector owinBufferPolicySelector)
        {
            _owinBufferPolicySelector = owinBufferPolicySelector;
        }

        public bool UseBufferedInputStream(object hostContext)
        {
            var context = hostContext as IOwinContext;

            if (context != null)
            {
                if (UnbufferedControllers.Any(x => context.Request.Uri.AbsolutePath.Contains("/" + x)))
                    return false;
            }

            return true;
        }

        public bool UseBufferedOutputStream(HttpResponseMessage response)
        {
            return _owinBufferPolicySelector.UseBufferedOutputStream(response);
        }
    }
}