using System.Threading.Tasks;
using FluentAssertions;
using Globomantics.BandAgent.Commands;
using Moq;
using Xunit;

namespace Globomantics.BandAgent.Tests
{
    public class CreateDeviceCommandTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsDeviceClient()
        {
            // Arrange
            Mock<IDeviceClientFactory> deviceClientFactoryMock = new Mock<IDeviceClientFactory>();
            deviceClientFactoryMock.Setup(m => m.CreateDeviceClient()).Returns(new Mock<IDeviceClient>().Object);

            var command = new CreateDeviceCommand(deviceClientFactoryMock.Object);
            
            // Act
            var deviceClient = await command.ExecuteAsync();

            // Assert
            deviceClient.Should().NotBeNull();
        }
    }
}
