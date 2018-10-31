using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public class DeviceEventDataReader : EventDataReader, IDeviceEventDataReader
    {
        public object ReadDeviceId(EventData eventData)
        {
            // ReSharper disable once StringLiteralTypo
            return eventData.SystemProperties["iothub-connection-device-id"];
        }
    }
}