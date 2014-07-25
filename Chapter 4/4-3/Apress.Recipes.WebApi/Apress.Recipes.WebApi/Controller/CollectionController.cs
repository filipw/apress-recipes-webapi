using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Apress.Recipes.WebApi.Controller
{
    public class CollectionController : ApiController
    {
        [Route("collection/numbers/{numbers}")]
        public HttpResponseMessage Get([ModelBinder(typeof (CollectionModelBinder<int>))] IEnumerable<int> numbers)
        {
            return Request.CreateResponse(HttpStatusCode.OK, numbers);
        }

        [Route("collection/words/{words}")]
        public HttpResponseMessage Get([ModelBinder(typeof (CollectionModelBinder<string>))] IEnumerable<string> words)
        {
            return Request.CreateResponse(HttpStatusCode.OK, words);
        }

    }
}