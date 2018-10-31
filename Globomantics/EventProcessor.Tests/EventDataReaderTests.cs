using FluentAssertions;
using Microsoft.Azure.EventHubs;
using Xunit;

namespace Globomantics.EventProcessor.Tests
{
    public class EventDataReaderTests
    {
        [Fact]
        public void ShouldReadPayload()
        {
            // Arrange
            var reader = new EventDataReader();
            var eventData = new EventData(EventDataReader.DefaultEncoding.GetBytes("foo"));

            // Act
            var payload = reader.ReadPayload(eventData);

            // Assert
            payload.Should().Be("foo");
        }
    }
}
