using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class TestController : ApiController
    {
        [Route("test")]
        [Authorize]
        public string Get()
        {
            return User.Identity.Name;
        }

    }
}