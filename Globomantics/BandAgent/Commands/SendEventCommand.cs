using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace Globomantics.BandAgent.Commands
{
    public class SendEventCommand : ICommand<string>
    {
        private readonly object _obj;
        private readonly IDeviceClient _deviceClient;

        public SendEventCommand(object obj, IDeviceClient deviceClient, IMessageFactory messageFactory)
        {
            _obj = obj;
            _deviceClient = deviceClient;
        }
        public async Task<string> ExecuteAsync(Dictionary<string, object> parameters = null)
        {
            var payload = JsonConvert.SerializeObject(_obj);
            var message = new Message(Encoding.ASCII.GetBytes(payload));

            await _deviceClient.SendEventAsync(message);

            return payload;
        }
    }
}
