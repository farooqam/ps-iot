using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.BandAgent.Commands;

namespace Globomantics.BandAgent
{
    class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Initializing...");

            var connectionString = "HostName=ps-iothub-fm.azure-devices.net;DeviceId=device1;SharedAccessKey=ZJNtwonsWec64h0N0sXaW4jaml5CJ5JVCZMIO8S9erQ=";
            var deviceClientFactory = new DeviceClientFactory(connectionString);
            var createDeviceCommand = new CreateDeviceCommand(deviceClientFactory);

            var deviceClient = await createDeviceCommand.ExecuteAsync();
            await deviceClient.OpenAsync();
            
            Console.WriteLine("Device is connected.");

            var updatePropertiesCommandParameters = new Dictionary<string, object>
            {
                {"connectionType", "wi-fi"},
                {"connectionStrength", "strong"}
            };

            var updatePropertiesCommand = new UpdateReportedPropertiesCommand(deviceClient);
            await updatePropertiesCommand.ExecuteAsync(updatePropertiesCommandParameters);

            while (true)
            {
                var obj = new { LuckyNumber = new Random().Next(100, 200), Ts = DateTime.UtcNow };
                var sendEventCommand = new SendEventCommand(deviceClient);

                var sendEventCommandParameters = new Dictionary<string, object>
                {
                    {"obj", obj}
                };

                await sendEventCommand.ExecuteAsync(sendEventCommandParameters);

                Console.WriteLine("Message sent.");
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}
