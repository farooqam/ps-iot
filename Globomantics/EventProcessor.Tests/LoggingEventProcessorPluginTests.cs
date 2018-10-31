using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Globomantics.EventProcessor;
using Globomantics.EventProcessor.Abstractions;
using Globomantics.EventProcessorHostController.Executable;
using Microsoft.Azure.EventHubs;
using Moq;
using Serilog;
using Xunit;
using IPartitionContextData = Globomantics.EventProcessor.Abstractions.IPartitionContextData;

namespace EventProcessor.Tests
{
    public class LoggingEventProcessorPluginTests
    {
        [Fact]
        public async Task ProcessEventsAsync_ReadsMessagePayloadAndDeviceId()
        {
            // Arrange
            var eventDataReaderMock = new Mock<IDeviceEventDataReader>();
            var loggerMock = new Mock<ILogger>();

            var plugin = new LoggingEventProcessorPlugin(
                eventDataReaderMock.Object,
                loggerMock.Object);

            var messages = new List<EventData>
            {
                new EventData(EventDataReader.DefaultEncoding.GetBytes("foo"))
            };
            
            // Act
            await plugin.ProcessEventsAsync(
                new Mock<IPartitionContextData>().Object,
                messages);

            // Assert
            eventDataReaderMock.Verify(m => m.ReadPayload(messages[0]), Times.Once);
            eventDataReaderMock.Verify(m => m.ReadDeviceId(messages[0]), Times.Once);
            plugin.ShouldCheckpoint.Should().BeTrue();
        }

        [Fact]
        public async Task ProcessEventsAsync_WhenNoMessages_DoesNotReadPayloadAndDeviceId()
        {
            // Arrange
            var eventDataReaderMock = new Mock<IDeviceEventDataReader>();
            var loggerMock = new Mock<ILogger>();

            var plugin = new LoggingEventProcessorPlugin(
                eventDataReaderMock.Object,
                loggerMock.Object);
            
            // Act
            await plugin.ProcessEventsAsync(
                new Mock<IPartitionContextData>().Object,
                new List<EventData>());

            // Assert
            eventDataReaderMock.Verify(m => m.ReadPayload(It.IsAny<EventData>()), Times.Never);
            eventDataReaderMock.Verify(m => m.ReadDeviceId(It.IsAny<EventData>()), Times.Never);
            plugin.ShouldCheckpoint.Should().BeTrue();
        }
    }
}
