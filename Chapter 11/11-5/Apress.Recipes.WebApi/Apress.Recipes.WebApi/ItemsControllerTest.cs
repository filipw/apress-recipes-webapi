using System;
using System.Net;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class ItemsControllerTest
    {
        [Fact]
        public void WhenGetIsCalledShouldRespondWithRedirectToOtherController()
        {
            var url = "http://www.test.com";
            var urlHelper = new Mock<UrlHelper>();
            urlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(url);
            
            var controller = new ItemsController {Url = urlHelper.Object};

            var result = controller.Get(5);

            Assert.Equal(HttpStatusCode.Redirect, result.StatusCode);
            Assert.Equal(new Uri(url), result.Headers.Location);
        }

        [Fact]
        public void WhenGetNewItemsIsCalledReturnTypeIsRedirectToRouteResult()
        {
            var controller = new ItemsController();
            var result = controller.GetNewItems(5);

            Assert.IsType<RedirectToRouteResult>(result);
        }
    }
}