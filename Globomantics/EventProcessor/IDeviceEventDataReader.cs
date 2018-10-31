using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public interface IDeviceEventDataReader : IEventDataReader
    {
        object ReadDeviceId(EventData eventData);
    }
}