using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class ContentCreation
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("platform")]
        public required string Platform { get; set; }

        [JsonProperty("description")]
        public required string Description { get; set; }

        [JsonProperty("language")]
        public required string Language { get; set; }

        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}
