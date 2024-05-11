using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    /// <summary>
    /// Represents a certification of a person.
    /// </summary>
    public partial class Certification
    {
        /// <summary>
        /// Title of the certification.
        /// </summary>
        [JsonProperty("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Description what the certification covers.
        /// </summary>
        [JsonProperty("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Name of the institution that issued the certification.
        /// </summary>
        [JsonProperty("instituation")]
        public required string? Instituation { get; set; }
    }
}
