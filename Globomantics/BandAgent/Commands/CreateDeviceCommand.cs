using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globomantics.BandAgent.Commands
{
    public class CreateDeviceCommand : ICommand<IDeviceClient>
    {
        private readonly string _connectionString;
        private readonly IDeviceClientFactory _deviceClientFactory;

        public CreateDeviceCommand(string connectionString, IDeviceClientFactory deviceClientFactory)
        {
            _connectionString = connectionString;
            _deviceClientFactory = deviceClientFactory;
        }

        public Task<IDeviceClient> ExecuteAsync(Dictionary<string, object> parameters = null)
        {
            return Task.FromResult(_deviceClientFactory.CreateFromConnectionString(_connectionString));
        }
    }
}
