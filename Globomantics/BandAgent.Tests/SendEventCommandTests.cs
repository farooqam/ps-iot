using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Globomantics.BandAgent.Commands;
using Microsoft.Azure.Devices.Client;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Globomantics.BandAgent.Tests
{
    public class SendEventCommandTests
    {
        [Fact]
        public async Task ExecuteAsync_SendsEvent()
        {
            // Arrange
            var deviceClientMock = new Mock<IDeviceClient>();
            var command = new SendEventCommand(deviceClientMock.Object);
            var commandParameters = new Dictionary<string, object>
            {
                {"obj", new {name = "foo"}}
            };

            // Act
            await command.ExecuteAsync(commandParameters);

            // Assert
            deviceClientMock.Verify(
                m => m.SendEventAsync(It.IsAny<Message>()),
                Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsPayload()
        {
            // Arrange
            var deviceClientMock = new Mock<IDeviceClient>();
            var command = new SendEventCommand(deviceClientMock.Object);
            var commandParameters = new Dictionary<string, object>
            {
                {"obj", new {name = "foo"}}
            };

            // Act
            var result = await command.ExecuteAsync(commandParameters);

            // Assert
            var jo = JObject.Parse(result);
            ((string)jo["name"]).Should().Be("foo");
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsPayloadInCamelCase()
        {
            // Arrange
            var deviceClientMock = new Mock<IDeviceClient>();
            var command = new SendEventCommand(deviceClientMock.Object);
            var commandParameters = new Dictionary<string, object>
            {
                {"obj", new {Name = "foo"}}
            };

            // Act
            var result = await command.ExecuteAsync(commandParameters);

            // Assert
            var jo = JObject.Parse(result);
            ((string)jo["name"]).Should().Be("foo");
        }
    }
}
