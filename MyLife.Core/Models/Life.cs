using MyLife.Core.Models.Coding;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public record Life
    (
        [JsonProperty("last_updated")]
        DateTimeOffset LastUpdated,

        [JsonProperty("language")]
        string Language,

        [JsonProperty("version")]
        string Version,

        [JsonProperty("persona")]
        Persona Persona,

        [JsonProperty("content_creation_profiles")]
        ContentCreation[] ContentCreation,

        [JsonProperty("project_families")]
        ProjectFamily[] ProjectFamilies,

        [JsonProperty("curriculumvitae")]
        CurriculumVitae.CurriculumVitae CurriculumVitae,

        [JsonProperty("socialmedia")]
        SocialMedia[] Socialmedia
    );
}
