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
        /// Name of the institution that issued the certification.
        /// </summary>
        [JsonProperty("instituation")]
        public required string Instituation { get; set; }

        /// <summary>
        /// Year of certification took place.
        /// </summary>
        [JsonProperty("year_of_certification")]
        public required int? YearOfCertification { get; set; }
    }
}
