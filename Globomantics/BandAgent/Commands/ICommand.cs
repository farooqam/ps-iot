using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globomantics.BandAgent.Commands
{
    public interface ICommand<TOut>
    {
        Task<TOut> ExecuteAsync(Dictionary<string, object> parameters = null);
    }
}
