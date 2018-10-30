using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Shared;

namespace Globomantics.BandAgent.Commands
{
    public class UpdateReportedPropertiesCommand : ICommand<TwinCollection>
    {
        private readonly IDeviceClient _deviceClient;

        public UpdateReportedPropertiesCommand(IDeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }
        public async Task<TwinCollection> ExecuteAsync(Dictionary<string, object> parameters)
        {
            var twinCollection = new TwinCollection();

            foreach (var parameter in parameters)
            {
                twinCollection[parameter.Key] = parameter.Value;
            }

            await _deviceClient.UpdateReportedPropertiesAsync(twinCollection);

            return twinCollection;
        }
    }
}
