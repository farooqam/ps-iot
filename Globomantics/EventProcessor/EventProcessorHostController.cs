using System.Threading.Tasks;
using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs.Processor;

namespace Globomantics.EventProcessorHostController.Executable
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
            _processor = new EventProcessorHost(
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
