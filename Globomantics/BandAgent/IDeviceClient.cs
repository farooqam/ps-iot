using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.BandAgent
{
    public interface IDeviceClient
    {
        Task OpenAsync();
        Task SendEventAsync(IMessage message);
    }
}
