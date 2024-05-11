using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    /// <summary>
    /// One person's life.
    /// </summary>
    public partial class Life
    {
        /// <summary>
        /// Last updated date of the information.
        /// </summary>
        [JsonProperty("last_updated")]
        public required DateTimeOffset LastUpdated { get; set; }

        /// <summary>
        /// Version of the life information.
        /// </summary>
        [JsonProperty("version")]
        public required string Version { get; set; }

        /// <summary>
        /// Language of the information.
        /// </summary>
        [JsonProperty("language")]
        public required string Language { get; set; }

        /// <summary>
        /// Generic personal information.
        /// </summary>
        [JsonProperty("persona")]
        public required Persona.Container Persona { get; set; }

        /// <summary>
        /// List of content creation profiles.
        /// </summary>
        [JsonProperty("content_creation")]
        public required ContentCreation.Container ContentCreation { get; set; }

        /// <summary>
        /// Information covering open source work of the person.
        /// </summary>
        [JsonProperty("open_source")]
        public required OpenSource.Container OpenSource { get; set; }

        /// <summary>
        /// Information covering the person's curriculum vitae.
        /// </summary>
        [JsonProperty("curriculum_vitae")]
        public required CurriculumVitae.Container CurriculumVitae { get; set; }

        /// <summary>
        /// List of social media accounts.
        /// </summary>
        [JsonProperty("social_media")]
        public required SocialMedia.Container SocialMedia { get; set; }
    };
}
