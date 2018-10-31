using System.Threading.Tasks;
using Microsoft.Azure.EventHubs.Processor;

namespace Globomantics.EventProcessor
{
    public class EventProcessorHostController : IEventProcessorHostController
    {
        private readonly IEventProcessorFactory _eventProcessorFactory;
        private readonly EventProcessorHost _processor;

        public EventProcessorHostController(
            IEventProcessorFactory eventProcessorFactory,
            EventProcessorHostControllerSettings settings)
        {
            _eventProcessorFactory = eventProcessorFactory;
            _processor = new Microsoft.Azure.EventHubs.Processor.EventProcessorHost(
                settings.EventHubName,
                settings.ConsumerGroupName,
                settings.EventHubConnectionString,
                settings.StorageConnectionString,
                settings.LeaseContainerName);
        }

        public async Task StartEventProcessorHostAsync()
        {
            await _processor.RegisterEventProcessorFactoryAsync(_eventProcessorFactory);
        }

        public async Task StopEventProcessorHostAsync()
        {
            await _processor.UnregisterEventProcessorAsync();
        }
    }
}
