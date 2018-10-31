using Globomantics.EventProcessor.Abstractions;
using Microsoft.Azure.EventHubs.Processor;

namespace Globomantics.EventProcessorHostController.Executable
{
    public class PartitionContextData : IPartitionContextData
    {
        public PartitionContextData(PartitionContext context)
        {
            PartitionId = context.PartitionId;
            ConsumerGroupName = context.ConsumerGroupName;
            EventHubPath = context.EventHubPath;
            Owner = context.Owner;
        }

        public string Owner { get; }

        public string EventHubPath { get; }

        public string ConsumerGroupName { get; }

        public string PartitionId { get; }

        public static explicit operator PartitionContextData(PartitionContext context)
        {
            return new PartitionContextData(context);
        }
    }
}
