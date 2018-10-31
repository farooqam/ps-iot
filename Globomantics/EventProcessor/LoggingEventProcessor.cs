using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Serilog;

namespace Globomantics.EventProcessor
{
    public class LoggingEventProcessor : IEventProcessor
    {
        private readonly ILogger _logger;

        public LoggingEventProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public Task OpenAsync(PartitionContext context)
        {
            _logger.Debug("LoggingEventProcessor opened, processing partition: {PartitionId}", context.PartitionId);
            return Task.CompletedTask;
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            _logger.Debug("LoggingEventProcessor closing, partition: {PartitionId}, reason: {Reason}", context.PartitionId, reason);
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            _logger.Error("LoggingEventProcessor error, partition: {PartitionId}, error: {Error}", context.PartitionId, error.Message);
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            _logger.Debug("Batch of events received on partition: {PartitionId}", context.PartitionId);

            foreach (var eventData in messages)
            {
                var payload = Encoding.ASCII.GetString(eventData.Body.Array,
                    eventData.Body.Offset,
                    eventData.Body.Count);

                var deviceId = eventData.SystemProperties["iothub-connection-device-id"];

                _logger.Information("Message received on partition {PartitionId}, device ID: {DeviceId}, payload: {Payload}",
                    context.PartitionId,
                    deviceId,
                    payload);

                //var telemetry = JsonConvert.DeserializeObject<Telemetry>(payload);

                //if (telemetry.Status == StatusType.Emergency)
                //{
                //    Console.WriteLine($"Guest requires emergency assistance! Device ID: {deviceId}");
                //}
            }
            return context.CheckpointAsync();
        }
    }
}
