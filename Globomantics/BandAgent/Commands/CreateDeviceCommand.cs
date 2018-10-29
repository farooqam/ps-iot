using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace Globomantics.BandAgent.Commands
{
    public class CreateDeviceCommand : ICommand<DeviceClient>
    {
        private readonly string _connectionString;

        public CreateDeviceCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<DeviceClient> ExecuteAsync(Dictionary<string, object> parameters = null)
        {
            return Task.FromResult(DeviceClient.CreateFromConnectionString(_connectionString));
        }
    }
}
