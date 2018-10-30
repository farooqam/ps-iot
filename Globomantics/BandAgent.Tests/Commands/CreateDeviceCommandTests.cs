using System.Threading.Tasks;
using FluentAssertions;
using Globomantics.BandAgent.Commands;
using Moq;
using Xunit;

namespace Globomantics.BandAgent.Tests.Commands
{
    public class CreateDeviceCommandTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsDeviceClient()
        {
            // Arrange
            Mock<IDeviceClientFactory> deviceClientFactoryMock = new Mock<IDeviceClientFactory>();
            var expectedDeviceClient = new Mock<IDeviceClient>().Object;
            deviceClientFactoryMock.Setup(m => m.CreateDeviceClient()).Returns(expectedDeviceClient);

            var command = new CreateDeviceCommand(deviceClientFactoryMock.Object);
            
            // Act
            var deviceClient = await command.ExecuteAsync();

            // Assert
            deviceClient.Should().Be(expectedDeviceClient);
        }
    }
}
