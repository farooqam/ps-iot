using System.Text;
using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public class EventDataReader : IEventDataReader
    {
        public static Encoding DefaultEncoding => Encoding.ASCII;

        public string ReadPayload(EventData eventData)
        {
            return DefaultEncoding.GetString(eventData.Body.Array,
                eventData.Body.Offset,
                eventData.Body.Count);
        }
    }
}
