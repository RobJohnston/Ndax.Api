using System.Collections.Generic;
using System.Threading.Tasks;
using Ndax.Api.Models;

namespace Ndax.Api
{
    public interface INdaxClient
    {
        Task<Dictionary<string, Instrument>> GetTickerAsync();
    }
}
