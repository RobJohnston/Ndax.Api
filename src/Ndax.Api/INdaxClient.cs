using System.Collections.Generic;
using System.Threading.Tasks;
using Ndax.Api.Models;
using Refit;

namespace Ndax.Api
{
    public interface INdaxClient
    {
        [Get("/v1/ticker")]
        Task<Dictionary<string, Instrument>> GetTickerAsync();
    }
}
