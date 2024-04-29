using MyLife.Core.Models.Shared;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class SocialMedia
    {
        [JsonProperty("username")]
        public required string Username { get; set; }

        [JsonProperty("platform")]
        public required Platform Platform { get; set; }

        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}