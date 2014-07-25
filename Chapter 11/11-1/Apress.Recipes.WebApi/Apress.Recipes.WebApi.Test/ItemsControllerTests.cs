using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Routing;
using AssertExLib;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi.Test
{
    public class ItemsControllerTests
    {
        [Fact]
        public async void WhenItemIsPostedResponseShouldBe201AndLocationHeaderShouldBeSet()
        {
            var item = new Item
            {
                Id = 1,
                Name = "Filip"
            };
            var service = new Mock<IItemService>().Object;
            var controller = new ItemsController(service)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost/items")
                }
            };
            controller.Configuration.MapHttpAttributeRoutes();
            controller.Configuration.EnsureInitialized();
            controller.RequestContext.RouteData = new HttpRouteData(
                new HttpRoute(), new HttpRouteValueDictionary { { "controller", "Items" } });

            var result = await controller.Post(item);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.Equal("http://localhost/items/1", result.Headers.Location.AbsoluteUri);
        }

        [Fact]
        public void WhenItemIsPostedAndIsInvalidThrowsBadRequest()
        {
            var item = new Item
            {
                Id = 1
            };
            var service = new Mock<IItemService>().Object;
            var controller = new ItemsController(service)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost/items")
                }
            };
            controller.ModelState.AddModelError("Name", "Name is required");

            var ex = AssertEx.TaskThrows<HttpResponseException>(async () => await controller.Post(item));
            Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
        }

        [Fact]
        public async void WhenGetByIdIsCalledUnderlyingServiceIsCalled()
        {
            var item = new Item {Id = 1, Name = "Filip"};
            var service = new Mock<IItemService>();
            service.Setup(x => x.GetById(1)).Returns(Task.FromResult(item));
            var controller = new ItemsController(service.Object);
            var result = await controller.Get(1);

            Assert.Equal(item, result);
        }

        [Fact]
        public void WhenIdCalledByGetByIdIsNotFound404IsThrown()
        {
            var service = new Mock<IItemService>();
            service.Setup(x => x.GetById(1)).Returns(Task.FromResult<Item>(null));
            var controller = new ItemsController(service.Object);

            var ex = AssertEx.TaskThrows<HttpResponseException>(async () => await controller.Get(1));
            Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
        }
    }
}
