using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record Publication
    (
        [JsonProperty("title")]
        string Title,

        [JsonProperty("publisher")]
        string Publisher,

        [JsonProperty("year")]
        int Year
    );
}
