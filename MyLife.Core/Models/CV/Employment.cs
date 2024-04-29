using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Employment {
        [JsonProperty("company")]
        public required string Company { get; set; }

        [JsonProperty("role")]
        public required string Role { get; set; }

        [JsonProperty("tasks")]
        public required string[] Tasks { get; set; }

        [JsonProperty("joined")]
        public required string Joined { get; set; }

        [JsonProperty("left")]
        public required string? Left { get; set; }
    }

}
