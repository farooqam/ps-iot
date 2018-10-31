using System.Text;
using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public class EventDataReader : IEventDataReader
    {
        public Encoding DefaultEncoding => Encoding.ASCII;

        public string ReadPayload(EventData eventData)
        {
            return DefaultEncoding.GetString(eventData.Body.Array,
                eventData.Body.Offset,
                eventData.Body.Count);
        }
    }
}
