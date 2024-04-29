using MyLife.Core.Models.Shared;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class ContentCreation
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("platform")]
        public required Platform Platform { get; set; }

        [JsonProperty("description")]
        public required string Description { get; set; }

        [JsonProperty("language")]
        public required Language Language { get; set; }

        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}
