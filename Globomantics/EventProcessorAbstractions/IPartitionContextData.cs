namespace Globomantics.EventProcessor.Abstractions
{
    public interface IPartitionContextData
    {
        string ConsumerGroupName { get; }
        string EventHubPath { get; }
        string Owner { get; }
        string PartitionId { get; }
    }
}