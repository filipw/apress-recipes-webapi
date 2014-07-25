using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class ItemController : ApiController
    {
        [Route("item")]
        public HttpResponseMessage GetAll()
        {
            throw new Exception("This is a dreadful exception!");
        }
    }
}