using System.Text;
using Microsoft.Azure.EventHubs;

namespace Globomantics.EventProcessor
{
    public interface IEventDataReader
    {
        Encoding DefaultEncoding { get; }
        string ReadPayload(EventData eventData);
    }
}
