using Globomantics.BandAgent.Commands;

namespace Globomantics.BandAgent
{
    public interface IDeviceClientFactory
    {
        IDeviceClient CreateDeviceClient();
    }
}