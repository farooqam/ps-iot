using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Data.Edm.Csdl;

namespace Globomantics.BandAgent
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var connectionString = "HostName=ps-iothub-fm.azure-devices.net;DeviceId=device1;SharedAccessKey=ZJNtwonsWec64h0N0sXaW4jaml5CJ5JVCZMIO8S9erQ=";
            var device = DeviceClient.CreateFromConnectionString(connectionString);

            Console.WriteLine("Initializing...");

            await device.OpenAsync();

            Console.WriteLine("Device is connected.");
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
