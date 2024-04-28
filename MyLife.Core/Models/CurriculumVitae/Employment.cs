using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record Employment
    (
        [JsonProperty("company")]
        string Company,

        [JsonProperty("role")]
        string Role,

        [JsonProperty("tasks")]
        string[] Tasks,

        [JsonProperty("joined")]
        DateTimeOffset Joined,

        [JsonProperty("left")]
        DateTimeOffset? Left
    );
}
