using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class SocialMedia
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("profile_url")]
        public Uri Url { get; set; }
    }
}
