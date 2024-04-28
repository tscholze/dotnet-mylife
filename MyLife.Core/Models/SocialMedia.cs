using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public record SocialMedia(
        [JsonProperty("username")]
        string Username,

        [JsonProperty("platform")]
        string Platform,

        [JsonProperty("profile_url")]
        Uri Url
    );
}
