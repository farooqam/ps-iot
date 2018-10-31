using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor.Abstractions
{
    public interface IEventProcessorPlugin
    {
        Task ProcessEventsAsync(IPartitionContextData partitionContextData, IEnumerable<EventData> messages);
        bool ShouldCheckpoint { get; set; }
    }
}
