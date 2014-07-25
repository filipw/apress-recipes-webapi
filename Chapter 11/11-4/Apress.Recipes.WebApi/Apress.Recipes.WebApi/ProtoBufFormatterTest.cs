using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Moq;
using Xunit;

namespace Apress.Recipes.WebApi
{
    public class ProtoBufFormatterTest
    {
        [Fact]
        public void WhenInvokedContentShouldNotThrow()
        {
            var item = new Item {Id = 1, Name = "Filip"};
            Assert.DoesNotThrow(() => new ObjectContent<Item>(item, new ProtoBufFormatter()));
        }

        [Fact]
        public void WhenInvokedWithUnsupportedTypeContentShouldEmpty()
        {
            var item = new EvilItem { Id = 1, Name = "Filip" };
            Assert.Throws<InvalidOperationException>(() => new ObjectContent<EvilItem>(item, new ProtoBufFormatter()));
        }

        [Fact]
        public void WhenInvokedContentHeadersShouldBeSetCorrectly()
        {
            var item = new Item { Id = 1, Name = "Filip" };
            var content = new ObjectContent<Item>(item, new ProtoBufFormatter());

            Assert.Equal("application/x-protobuf", content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async void WhenUsedToDeserializeShouldCreateCorrectObject()
        {
            var formatter = new ProtoBufFormatter();
            var item = new Item { Id = 1, Name = "Filip" };
            var content = new ObjectContent<Item>(item, formatter);

            var deserializedItem = await content.ReadAsAsync<Item>(new[] {formatter});
            Assert.Same(item, deserializedItem);
        }

        [Fact]
        public void WhenCallingCanReadShouldNotBeAbleToReadTypesItDoesNotUnderstand()
        {
            var formatter = new ProtoBufFormatter();
            var canRead = formatter.CanReadType(typeof (EvilItem));
            Assert.False(canRead);
        }

        [Fact]
        public void WhenCallingCanWriteShouldNotBeAbleToWriteTypesItDoesNotUnderstand()
        {
            var formatter = new ProtoBufFormatter();
            var canWrite = formatter.CanWriteType(typeof(EvilItem));
            Assert.False(canWrite);
        }

        [Fact]
        public void WhenCallingCanReadShouldBeAbleToReadTypesItUnderstands()
        {
            var formatter = new ProtoBufFormatter();
            var canRead = formatter.CanReadType(typeof(Item));
            Assert.True(canRead);
        }

        [Fact]
        public void WhenCallingCanWriteShouldBeAbleToWriteTypesItUnderstands()
        {
            var formatter = new ProtoBufFormatter();
            var canWrite = formatter.CanWriteType(typeof(Item));
            Assert.True(canWrite);
        }

        [Fact]
        public async void WhenWritingToStreamShouldSuccessfullyComplete()
        {
            var formatter = new ProtoBufFormatter();
            var item = new Item { Id = 1, Name = "Filip" };

            var ms = new MemoryStream();
            await formatter.WriteToStreamAsync(typeof (Item), item, ms, new ByteArrayContent(new byte[0]),
                new Mock<TransportContext>().Object);

            var deserialized = ProtoBufFormatter.Model.Deserialize(ms, null, typeof (Item));

            Assert.Same(deserialized, item);
        }

        [Fact]
        public async void WhenReadingFromStreamShouldSuccessfullyComplete()
        {
            var formatter = new ProtoBufFormatter();
            var item = new Item { Id = 1, Name = "Filip" };

            var ms = new MemoryStream();
            ProtoBufFormatter.Model.Serialize(ms, item);

            var deserialized = await formatter.ReadFromStreamAsync(typeof(Item), ms, new ByteArrayContent(new byte[0]),
                new Mock<IFormatterLogger>().Object);

            Assert.Same(deserialized as Item, item);
        }
    }
}