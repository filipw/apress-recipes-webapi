using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class IntegrationTests
    {
        private readonly HttpServer _server;
        private const string Url = "http://www.apress.com/";
        private readonly Mock<ILoggingService> _loggingService;

        public IntegrationTests()
        {
            _loggingService = new Mock<ILoggingService>();

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new LoggingHandler {LoggingService = _loggingService.Object});
            _server = new HttpServer(config);
        }

        [Fact]
        public async void GetHelloReturnsCorrectResponse()
        {
            var client = new HttpClient(_server);
            var response = await client.GetAsync(Url + "hello");
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello World", result);
        }

        [Fact]
        public async void GetHelloSetsMaxAgeTo100()
        {
            var client = new HttpClient(_server);
            var response = await client.GetAsync(Url + "hello");

            Assert.Equal(TimeSpan.FromSeconds(100), response.Headers.CacheControl.MaxAge);
        }

        [Fact]
        public async void GetHelloGoesThroughLoggingHandler()
        {
            var client = new HttpClient(_server);
            var response = await client.GetAsync(Url + "hello");

            _loggingService.Verify(i => i.Log("http://www.apress.com/hello"), Times.Once);
        }

        [Fact]
        public async void PostCanRespondInXml()
        {
            var message = new MessageDto
            {
                Text = "This is XML"
            };
            var client = new HttpClient(_server);
            var response = await client.PostAsXmlAsync(Url + "hello", message);

            var result = await response.Content.ReadAsAsync<MessageDto>(new [] {new XmlMediaTypeFormatter() });
            
            Assert.Equal(message.Text, result.Text);
        }


        [Fact]
        public async void PostCanRespondInJson()
        {
            var message = new MessageDto
            {
                Text = "This is JSON"
            };
            var client = new HttpClient(_server);
            var response = await client.PostAsJsonAsync(Url + "hello", message);

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