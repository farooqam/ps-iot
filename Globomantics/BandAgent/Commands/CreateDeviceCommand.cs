using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globomantics.BandAgent.Commands
{
    public class CreateDeviceCommand : ICommand<IDeviceClient>
    {
        private readonly IDeviceClientFactory _deviceClientFactory;

        public CreateDeviceCommand(IDeviceClientFactory deviceClientFactory)
        {
            _deviceClientFactory = deviceClientFactory;
        }

        public Task<IDeviceClient> ExecuteAsync(Dictionary<string, object> parameters = null)
        {
            return Task.FromResult(_deviceClientFactory.CreateDeviceClient());
        }
    }
}
