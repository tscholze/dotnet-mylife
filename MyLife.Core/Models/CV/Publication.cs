using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Publication
    {
        [JsonProperty("title")]
        public required string Title { get; set; }

        [JsonProperty("publisher")]
        public required string Publisher { get; set; }

        [JsonProperty("year")]
        public required int Year { get; set; }
    }
}
