using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

namespace Globomantics.BandAgent
{
    public class DeviceClientWrapper : IDeviceClient
    {
        private readonly DeviceClient _deviceClient;

        public DeviceClientWrapper(string connectionString)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task OpenAsync()
        {
            await _deviceClient.OpenAsync();
        }

        public async Task UpdateReportedPropertiesAsync(TwinCollection twinCollection)
        {
            await _deviceClient.UpdateReportedPropertiesAsync(twinCollection);
        }

        public async Task SendEventAsync(Message message)
        {
            await _deviceClient.SendEventAsync(message);
        }
    }
}
