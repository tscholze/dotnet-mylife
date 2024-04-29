using MyLife.Core.Models.CV;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class Life
    {
        [JsonProperty("last_updated")]
        public required DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("version")]
        public required string Version { get; set; }

        [JsonProperty("language")]
        public required string Language { get; set; }

        [JsonProperty("persona")]
        public required Persona Persona { get; set; }

        [JsonProperty("content_creation_profiles")]
        public required ContentCreation[] ContentCreation { get; set; }

        [JsonProperty("open_source")]
        public required OpenSource OpenSource { get; set; }

        [JsonProperty("curriculum_vitae")]
        public required CurriculumVitae CurriculumVitae { get; set; }

        [JsonProperty("social_media")]
        public required SocialMedia[] SocialMedia { get; set; }
    };
}
