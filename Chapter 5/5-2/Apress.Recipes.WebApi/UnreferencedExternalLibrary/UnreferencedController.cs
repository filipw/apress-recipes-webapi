using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UnreferencedExternalLibrary
{
    public class UnreferencedController : ApiController
    {
        public string Get()
        {
            return "Hello from unreferenced lib!";
        }
    }
}
