using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Employment {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("tasks")]
        public string[] Tasks { get; set; }

        [JsonProperty("joined")]
        public string Joined { get; set; }

        [JsonProperty("left")]
        public string? Left { get; set; }
    }

}
