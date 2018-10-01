using Ndax.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ndax.Api
{
    public partial class NdaxClient
    {
        /// <summary>
        /// Get the current trading information.
        /// </summary>
        /// <returns>Trading information for all <see cref="Instrument"/>s.</returns>
        /// <exception cref="HttpRequestException">There was a problem with the HTTP request.</exception>
        public async Task<Dictionary<string, Instrument>> GetTickerAsync()
        {
            return await QueryPublicAsync<Dictionary<string, Instrument>>(
                "returnticker",
                null
            );
        }
    }
}
