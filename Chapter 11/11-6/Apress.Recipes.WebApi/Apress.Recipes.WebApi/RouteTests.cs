using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class RouteTests
    {
        readonly HttpConfiguration _config;

        public RouteTests()
        {
            _config = new HttpConfiguration();
            _config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
        }

        [Fact]
        public void ItemsControllerGetIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.apress.com/api/items/");
            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(ItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((ItemsController p) => p.Get())));
        }

        [Fact]
        public void ItemsControllerGetByIdIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.apress.com/api/items/7");
            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(ItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((ItemsController p) => p.Get(7))));
        }

        [Fact]
        public void ItemsControllerPostIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://www.apress.com/api/items/");
            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(ItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((ItemsController p) => p.Post(new Item()))));
        }
    }
}