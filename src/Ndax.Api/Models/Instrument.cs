using Newtonsoft.Json;

namespace Ndax.Api.Models
{
    /// <summary>
    /// Represent a single trading instrument.
    /// </summary>
    public partial class Instrument
    {
        [JsonProperty("isFrozen")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsFrozen { get; set; }

        [JsonProperty("lowestAsk")]
        public decimal LowestAsk { get; set; }

        [JsonProperty("highestBid")]
        public decimal HighestBid { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("high24hr")]
        public decimal High24Hr { get; set; }

        [JsonProperty("low24hr")]
        public decimal Low24Hr { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("percentChange")]
        public decimal PercentChange { get; set; }

        [JsonProperty("baseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonProperty("quoteVolume")]
        public decimal QuoteVolume { get; set; }
    }
}
