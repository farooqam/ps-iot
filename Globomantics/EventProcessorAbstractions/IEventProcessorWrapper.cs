using System.Threading.Tasks;

namespace Globomantics.EventProcessor.Abstractions
{
    public interface IEventProcessorWrapper
    {
        Task StartEventProcessorHostAsync();
        Task StopEventProcessorHostAsync();
    }
}
