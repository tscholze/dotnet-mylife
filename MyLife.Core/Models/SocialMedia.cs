using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class SocialMedia
    {
        [JsonProperty("username")]
        public required string Username { get; set; }

        [JsonProperty("platform")]
        public required string Platform { get; set; }

        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}
