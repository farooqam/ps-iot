using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Serilog;

namespace Globomantics.EventProcessor
{
    public class EventProcessorContainer : IEventProcessor
    {
        private readonly ILogger _logger;
        private readonly IEventProcessorPlugin _eventProcessorPlugin;

        public EventProcessorContainer(IEventProcessorPlugin eventProcessorPlugin, ILogger logger)
        {
            _eventProcessorPlugin = eventProcessorPlugin;
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

        public async Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            _logger.Debug("Batch of events received on partition: {PartitionId}", context.PartitionId);
            await _eventProcessorPlugin.ProcessEventsAsync((PartitionContextData) context, messages);

            if (_eventProcessorPlugin.ShouldCheckpoint)
            {
                _logger.Debug("Checkpointing");
                await context.CheckpointAsync();
            }
        }
    }
}
