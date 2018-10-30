using Microsoft.Azure.EventHubs.Processor;

namespace Globomantics.EventProcessor
{
    public class EventProcessorFactory : IEventProcessorFactory
    {
        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            return new LoggingEventProcessor();
        }
    }
}
