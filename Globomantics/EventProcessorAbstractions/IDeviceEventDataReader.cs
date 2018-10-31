using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor.Abstractions
{
    public interface IDeviceEventDataReader : IEventDataReader
    {
        object ReadDeviceId(EventData eventData);
    }
}