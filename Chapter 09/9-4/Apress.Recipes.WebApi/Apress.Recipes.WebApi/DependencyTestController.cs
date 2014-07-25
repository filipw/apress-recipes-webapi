using System.Web.Http;

namespace Apress.Recipes.WebApi
{
    public class DependencyTestController : ApiController
    {
        private readonly IService _service;

        public DependencyTestController(IService service)
        {
            _service = service;
        }

        [Route("dependency")]
        [MyActionFilter]
        public string Get()
        {
            return _service.SaySomething("Something from a controller");
        }
    }
}