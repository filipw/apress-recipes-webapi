using System.Collections.Generic;
using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    [MvcBindingConfiguration(ActionValueBinder = typeof(MvcActionValueBinder))]
    public class MyController : ApiController
    {
        [Route("my")]
        public MyComplexDto Post(MyComplexDto dto)
        {
            return dto;
        }
    }
}