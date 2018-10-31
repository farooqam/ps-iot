using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public class DeviceEventDataReader : EventDataReader, IDeviceEventDataReader
    {
        public object ReadDeviceId(EventData eventData)
        {
            return eventData.SystemProperties["iothub-connection-device-id"];
        }
    }
}