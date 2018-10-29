using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Data.Edm.Csdl;
using Newtonsoft.Json;

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

            var twinCollection = new TwinCollection();
            twinCollection["connectionType"] = "wi-fi";
            twinCollection["connectionStrength"] = "weak";

            await device.UpdateReportedPropertiesAsync(twinCollection);
            
            while (true)
            {
                var obj = new {LuckyNumber = new Random().Next(100, 200), Ts = DateTime.UtcNow};
                var payload = JsonConvert.SerializeObject(obj);
                var message = new Message(Encoding.ASCII.GetBytes(payload));

                await device.SendEventAsync(message);

                Console.WriteLine("Message sent.");
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}
