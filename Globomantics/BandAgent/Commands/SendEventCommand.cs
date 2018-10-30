using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Globomantics.BandAgent.Commands
{
    public class SendEventCommand : ICommand<string>
    {
        private readonly IDeviceClient _deviceClient;
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public SendEventCommand(IDeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }
        public async Task<string> ExecuteAsync(Dictionary<string, object> parameters)
        {
            var objectToSend = parameters["obj"];
            var payload = JsonConvert.SerializeObject(objectToSend, JsonSerializerSettings);
            var message = new Message(Encoding.ASCII.GetBytes(payload));

            await _deviceClient.SendEventAsync(message);

            return payload;
        }
    }
}
