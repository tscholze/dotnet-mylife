using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    public record ProjectFamily
    (
        [JsonProperty("name")]
        string Name,

        [JsonProperty("description")]
        string Description,

        [JsonProperty("description")]
        Project[] Projects,

        [JsonProperty("image_url")]
        Uri ImageUrl
    );
}
