using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record Certification
    (
        [JsonProperty("title")]
        string Title,

        [JsonProperty("description")]
        string Description,

        [JsonProperty("instituation")]
        string? Instituation
    );
}
