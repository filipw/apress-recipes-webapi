using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TextController : ApiController
    {
        [Route("text")]
        [CheckModelForNull]
        public string Post([FromBody] string text)
        {
            //echo input
            return text;
        }
    }
}