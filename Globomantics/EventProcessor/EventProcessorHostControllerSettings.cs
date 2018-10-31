namespace Globomantics.EventProcessor
{
    public class EventProcessorHostControllerSettings
    {
        public string EventHubName { get; set; }
        public string EventHubConnectionString { get; set; }
        public string ConsumerGroupName { get; set; }
        public string StorageConnectionString { get; set; }
        public string LeaseContainerName { get; set; }
    }
}
