using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    /// <summary>
    /// Represents a publication of a person.
    /// </summary>
    public partial class Publication
    {
        /// <summary>
        /// Title of the publication.
        /// </summary>
        [JsonProperty("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Publisher / Event of the publication.
        /// </summary>
        [JsonProperty("publisher")]
        public required string Publisher { get; set; }

        /// <summary>
        /// Year of publication.
        /// </summary>
        [JsonProperty("year")]
        public required int Year { get; set; }
    }
}
