using Microsoft.Azure.EventHubs.Processor;
using Serilog;

namespace Globomantics.EventProcessor
{
    public class EventProcessorFactory : IEventProcessorFactory
    {
        private readonly ILogger _logger;

        public EventProcessorFactory(ILogger logger)
        {
            _logger = logger;
        }
        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            return new LoggingEventProcessor(_logger);
        }
    }
}
