using MyLife.Core.Models.Coding;
using MyLife.Core.Models.CV;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class Life
    {
        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("persona")]
        public Persona Persona { get; set; }

        [JsonProperty("content_creation_profiles")]
        public ContentCreation[] ContentCreation { get; set; }

        [JsonProperty("open_source")]
        public OpenSource OpenSource { get; set; }

        [JsonProperty("curriculumvitae")]
        public CurriculumVitae CurriculumVitae { get; set; }

        [JsonProperty("socialmedia")]
        public SocialMedia[] SocialMedia { get; set; }
    };
}
