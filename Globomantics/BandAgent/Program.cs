using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Globomantics.BandAgent.Commands;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace Globomantics.BandAgent
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var device = await (new CreateDeviceCommand("HostName=ps-iothub-fm.azure-devices.net;DeviceId=device1;SharedAccessKey=ZJNtwonsWec64h0N0sXaW4jaml5CJ5JVCZMIO8S9erQ="))
                .ExecuteAsync();

            Console.WriteLine("Initializing...");

            await device.OpenAsync();

            Console.WriteLine("Device is connected.");

            var parameters = new Dictionary<string, object>
            {
                {"connectionType", "wi-fi"},
                {"connectionStrength", "strong"}
            };

            await (new UpdateReportedPropertiesTask(device)).ExecuteAsync(parameters);

            while (true)
            {
                var obj = new {LuckyNumber = new Random().Next(100, 200), Ts = DateTime.UtcNow};

                await (new SendEventCommand(obj, device)).ExecuteAsync();

                Console.WriteLine("Message sent.");
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}
