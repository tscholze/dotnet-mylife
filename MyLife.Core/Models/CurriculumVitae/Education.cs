using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    /// <summary>
    /// Stepf of education of a person.
    /// </summary>
    public partial class Education
    {
        /// <summary>
        /// Name of the institution.
        /// </summary>
        [JsonProperty("institution")]
        public required string Instituation { get; set; }

        /// <summary>
        /// Teaching content, subjects, etc.
        /// </summary>
        [JsonProperty("content")]
        public required string[] Content { get; set; }

        /// <summary>
        /// Title of the graduation.
        /// </summary>
        [JsonProperty("graduation")]
        public required string Graduation { get; set; }

        /// <summary>
        /// Year of graduation.
        /// </summary>
        [JsonProperty("year_of_graduation")]
        public required int YearOfGraduation { get; set; }
    }
}
