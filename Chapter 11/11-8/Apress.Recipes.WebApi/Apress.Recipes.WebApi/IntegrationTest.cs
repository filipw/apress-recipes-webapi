using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Testing;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class IntegrationTests
    {
        private readonly TestServer _server;
        private readonly Mock<ILoggingService> _loggingService;

        public IntegrationTests()
        {
            _loggingService = new Mock<ILoggingService>();
            _server = TestServer.Create<Startup>();
            LoggingMiddleware.LoggingService = new Lazy<ILoggingService>(() => _loggingService.Object);
        }

        [Fact]
        public async void GetHelloReturnsCorrectResponse()
        {
            var response = await _server.HttpClient.GetAsync("/hello");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello World", result);
        }

        [Fact]
        public async void GetHelloSetsMaxAgeTo100()
        {
            var response = await _server.HttpClient.GetAsync("/hello");
            Assert.Equal(TimeSpan.FromSeconds(100), response.Headers.CacheControl.MaxAge);
        }

        [Fact]
        public async void GetHelloGoesThroughLoggingHandler()
        {
            var response = await _server.HttpClient.GetAsync("/hello");
            _loggingService.Verify(i => i.Log("http://www.apress.com/hello"), Times.Once);
        }

        [Fact]
        public async void PostCanRespondInXml()
        {
            var message = new MessageDto
            {
                Text = "This is XML"
            };
            var response = await _server.HttpClient.PostAsXmlAsync("/hello", message);
            var result = await response.Content.ReadAsAsync<MessageDto>(new[] { new XmlMediaTypeFormatter() });

            Assert.Equal(message.Text, result.Text);
        }


        [Fact]
        public async void PostCanRespondInJson()
        {
            var message = new MessageDto
            {
                Text = "This is JSON"
            };
            var response = await _server.HttpClient.PostAsJsonAsync("/hello", message);
            var result = await response.Content.ReadAsAsync<MessageDto>(new[] { new JsonMediaTypeFormatter() });

            Assert.Equal(message.Text, result.Text);
        }


        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }
    }
}