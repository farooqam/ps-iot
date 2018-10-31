using System.Threading.Tasks;

namespace Globomantics.EventProcessor.Abstractions
{
    public interface IEventProcessorHostController
    {
        Task StartEventProcessorHostAsync();
        Task StopEventProcessorHostAsync();
    }
}
