using System.Threading.Tasks;

namespace Globomantics.EventProcessor
{
    public interface IEventProcessorHostController
    {
        Task StartEventProcessorHostAsync();
        Task StopEventProcessorHostAsync();
    }
}
