using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs.Processor;
using Serilog;

namespace Globomantics.EventProcessorHostController.Executable
{
    public class LoggingEventProcessorFactory : IEventProcessorFactory
    {
        private readonly ILogger _logger;
        private readonly IDeviceEventDataReader _eventDataReader;

        public LoggingEventProcessorFactory(ILogger logger, IDeviceEventDataReader eventDataReader)
        {
            _logger = logger;
            _eventDataReader = eventDataReader;
        }

        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            return new EventProcessorModule(new LoggingEventProcessorPlugin(_eventDataReader, _logger), _logger);
        }
    }
}
