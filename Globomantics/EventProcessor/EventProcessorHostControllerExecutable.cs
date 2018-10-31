using System;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Serilog;

// ReSharper disable StringLiteralTypo

namespace Globomantics.EventProcessorHostController.Executable
{
    class EventProcessorHostControllerExecutable
    {
        static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var eventProcessorHostControllerSettings = new EventProcessorHostControllerSettings
            {
                ConsumerGroupName = PartitionReceiver.DefaultConsumerGroupName,
                EventHubConnectionString =
                    "Endpoint=sb://ihsuprodbyres066dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=Lwo24+ra9w40Lz2vTS7CBTWsHPhvnKnXf2xPei1AAng=",
                EventHubName = "iothub-ehub-ps-iothub-906112-75e83745be",
                LeaseContainerName = "message-processor-host",
                StorageConnectionString =
                    "DefaultEndpointsProtocol=https;AccountName=psiotfmstorage;AccountKey=1uSJY+Uw4jwSEX/DvCFXCXBfxFcFW190madsMGgBr62mh+Q5/VGdJzwo4+512WitehPm0KfTGzn3c/GNfhtbBg==;EndpointSuffix=core.windows.net"
            };

            var eventProcessorHostController = new EventProcessorHostController(
                new LoggingEventProcessorFactory(Log.Logger, new DeviceEventDataReader()),
                eventProcessorHostControllerSettings);

            await eventProcessorHostController.StartEventProcessorHostAsync();
            
            Log.Logger.Information("Event processor started. Press ENTER to exit.");
            Console.ReadLine();

            Log.Logger.Information("Shutting down...");

            await eventProcessorHostController.StopEventProcessorHostAsync();

            Log.Logger.Information("Event processor has shut down.");

        }
    }
}
