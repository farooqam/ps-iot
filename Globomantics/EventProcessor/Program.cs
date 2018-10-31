﻿using System;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Serilog;

namespace Globomantics.EventProcessor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var hubName = "iothub-ehub-ps-iothub-906112-75e83745be";
            var iotHubConnectionString = "Endpoint=sb://ihsuprodbyres066dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=Lwo24+ra9w40Lz2vTS7CBTWsHPhvnKnXf2xPei1AAng=";
            var storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=psiotfmstorage;AccountKey=1uSJY+Uw4jwSEX/DvCFXCXBfxFcFW190madsMGgBr62mh+Q5/VGdJzwo4+512WitehPm0KfTGzn3c/GNfhtbBg==;EndpointSuffix=core.windows.net";
            var leaseContainerName = "message-processor-host";
            var consumerGroupName = PartitionReceiver.DefaultConsumerGroupName;

            var processor = new Microsoft.Azure.EventHubs.Processor.EventProcessorHost(
                hubName,
                consumerGroupName,
                iotHubConnectionString,
                storageConnectionString,
                leaseContainerName);

            await processor.RegisterEventProcessorFactoryAsync(new EventProcessorFactory(Log.Logger));
            
            Log.Logger.Information("Event processor started. Press ENTER to exit.");
            Console.ReadLine();

            Log.Logger.Information("Shutting down...");
            await processor.UnregisterEventProcessorAsync();
            Log.Logger.Information("Event processor has shut down.");

        }
    }
}
