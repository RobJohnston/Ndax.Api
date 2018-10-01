using System.Net.Http;

namespace Ndax.Api
{
    /// <summary>
    /// Request context.
    /// </summary>
    internal class RequestContext
    {
        /// <summary>
        /// Gets or sets the HTTP request object.
        /// </summary>
        public HttpRequestMessage HttpRequest { get; set; }
    }
}