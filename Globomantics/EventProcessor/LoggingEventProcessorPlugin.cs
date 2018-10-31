using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs;
using Serilog;

namespace Globomantics.EventProcessorHostController.Executable
{
    public class LoggingEventProcessorPlugin : IEventProcessorPlugin
    {
        private readonly IDeviceEventDataReader _eventDataReader;
        private readonly ILogger _logger;

        public LoggingEventProcessorPlugin(IDeviceEventDataReader eventDataReader, ILogger logger)
        {
            _eventDataReader = eventDataReader;
            _logger = logger;
        }

        public Task ProcessEventsAsync(IPartitionContextData partitionContextData, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var payload = _eventDataReader.ReadPayload(eventData);
                var deviceId = _eventDataReader.ReadDeviceId(eventData);
                
                _logger.Information("Message received on partition {PartitionId}, device ID: {DeviceId}, payload: {Payload}",
                    partitionContextData.PartitionId,
                    deviceId,
                    payload);

                //var telemetry = JsonConvert.DeserializeObject<Telemetry>(payload);

                //if (telemetry.Status == StatusType.Emergency)
                //{
                //    Console.WriteLine($"Guest requires emergency assistance! Device ID: {deviceId}");
                //}
            }

            ShouldCheckpoint = true;
            return Task.CompletedTask;
        }

        public bool ShouldCheckpoint { get; set; }
    }
}
