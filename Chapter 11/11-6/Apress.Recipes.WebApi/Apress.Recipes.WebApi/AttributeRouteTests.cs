using System.Net.Http;
using System.Web.Http;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class AttributeRouteTests
    {
        readonly HttpConfiguration _config;

        public AttributeRouteTests()
        {
            _config = new HttpConfiguration();
            _config.MapHttpAttributeRoutes();
            _config.EnsureInitialized();
        }

        [Fact]
        public void ItemsControllerGetIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.apress.com/coolitems/");

            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(HappyItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((HappyItemsController p) => p.GetAll())));
        }

        [Fact]
        public void ItemsControllerGetByIdIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://www.apress.com/coolitems/7");

            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(HappyItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((HappyItemsController p) => p.Get(7))));
        }

        [Fact]
        public void ItemsControllerPostIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://www.apress.com/coolitems/");

            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(HappyItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((HappyItemsController p) => p.Post(new Item()))));
        }

        [Fact]
        public void ItemsControllerDeleteIsCorrect()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://www.apress.com/coolitems/7");

            var routeTester = new RouteContext(_config, request);

            Assert.Equal(typeof(HappyItemsController), routeTester.ControllerType);
            Assert.True(routeTester.VerifyMatchedAction(ReflectionHelpers.GetMethodInfo((HappyItemsController p) => p.Delete(7))));
        }
    }
}