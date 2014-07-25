using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Apress.Recipes.WebApi.Controller
{
    public class BufferedController : BaseUploadController
    {
        [Route("buffered")]
        public virtual Task<List<string>> PostToMemory()
        {
            //this will indicate buffering. Unbuffered input cannot be seeked
            Console.WriteLine(Request.Content.ReadAsStreamAsync().Result.CanSeek);
            return base.PostToMemory();
        }
    }
}