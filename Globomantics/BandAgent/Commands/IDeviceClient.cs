using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

namespace Globomantics.BandAgent.Commands
{
    public interface IDeviceClient
    {
        Task OpenAsync();
        Task UpdateReportedPropertiesAsync(TwinCollection twinCollection);
        Task SendEventAsync(Message message);
    }
}