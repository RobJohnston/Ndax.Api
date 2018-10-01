using System.Net.Http;

namespace Ndax.Api
{
    /// <summary>
    /// Response context.
    /// </summary>
    internal class ResponseContext
    {
        /// <summary>
        /// Gets or sets the HTTP response object.
        /// </summary>
        public HttpResponseMessage HttpResponse { get; set; }
    }
}