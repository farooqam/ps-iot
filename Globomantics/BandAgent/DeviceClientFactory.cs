using Globomantics.BandAgent.Commands;

namespace Globomantics.BandAgent
{
    public class DeviceClientFactory : IDeviceClientFactory
    {
        private readonly string _connectionString;

        public DeviceClientFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDeviceClient CreateDeviceClient()
        {
            return new DeviceClientWrapper(_connectionString);
        }
    }
}
