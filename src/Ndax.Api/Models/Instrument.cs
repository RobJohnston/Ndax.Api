using System.Text.Json.Serialization;

namespace Ndax.Api.Models
{
    /// <summary>
    /// Represent a single trading instrument.
    /// </summary>
    public partial class Instrument
    {
        [JsonPropertyName("isFrozen")]
        public bool IsFrozen { get; set; }

        [JsonPropertyName("lowestAsk")]
        public decimal LowestAsk { get; set; }

        [JsonPropertyName("highestBid")]
        public decimal HighestBid { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("high24hr")]
        public decimal? High24Hr { get; set; }

        [JsonPropertyName("low24hr")]
        public decimal? Low24Hr { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("percentChange")]
        public decimal? PercentChange { get; set; }

        [JsonPropertyName("baseVolume")]
        public decimal? BaseVolume { get; set; }

        [JsonPropertyName("quoteVolume")]
        public decimal? QuoteVolume { get; set; }
    }
}
