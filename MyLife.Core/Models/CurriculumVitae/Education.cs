using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record Education
    (
        [JsonProperty("institution")]
        string Instituation,

        [JsonProperty("description")]
        string Description,

        [JsonProperty("graduation")]
        string Graduation,

        [JsonProperty("year_of_graduation")]
        int YearOfGraduation
    );
}
