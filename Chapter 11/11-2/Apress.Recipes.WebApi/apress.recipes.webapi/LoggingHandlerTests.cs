using System;
using System.Net.Http;
using System.Threading;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class LoggingHandlerTests
    {
        [Fact]
        public async void WhenCalledShouldLogTheRequestUrl()
        {
            var mockLogger = new Mock<ILoggingService>();
            var handler = new LoggingHandler
            {
                LoggingService = mockLogger.Object
            };

            var invoker = new HttpMessageInvoker(handler);
            var result = await invoker.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri("http://test.com/resource")), CancellationToken.None);

            mockLogger.Verify(x => x.Log("http://test.com/resource"), Times.Once);
        }

    }
}