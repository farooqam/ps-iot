using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Globomantics.BandAgent.Commands;
using Microsoft.Azure.Devices.Shared;
using Moq;
using Xunit;

namespace Globomantics.BandAgent.Tests
{
    public class UpdateReportedPropertiesCommandTests
    {
        [Fact]
        public async Task ExecuteAsync_UpdatesDeviceProperties()
        {
            // Arrange
            Mock<IDeviceClient> deviceClientMock = new Mock<IDeviceClient>();
            var command = new UpdateReportedPropertiesCommand(deviceClientMock.Object);
            var commandParameters = new Dictionary<string, object>();

            // Act
            await command.ExecuteAsync(commandParameters);

            // Assert
            deviceClientMock.Verify(
                m => m.UpdateReportedPropertiesAsync(
                    It.IsAny<TwinCollection>()), 
                Times.Once);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsTwinCollection()
        {
            // Arrange
            Mock<IDeviceClient> deviceClientMock = new Mock<IDeviceClient>();
            var command = new UpdateReportedPropertiesCommand(deviceClientMock.Object);
            var commandParameters = new Dictionary<string, object>
            {
                {"key", "val"}
            };

            // Act
            var actualTwinCollection = await command.ExecuteAsync(commandParameters);

            // Assert
            ((string) actualTwinCollection["key"]).Should().Be("val");
        }
    }
}
