using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor.Abstractions
{
    public interface IEventDataReader
    {
        string ReadPayload(EventData eventData);
    }
}
