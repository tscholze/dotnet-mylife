using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    /// <summary>
    /// Represents a family of projects.
    /// Most of the time, these projects are tech-stack or 
    /// usecase related to each other.
    /// </summary>
    public partial class ProjectFamily
    {
        /// <summary>
        /// Name of the project family.
        /// </summary>
        [JsonProperty("name")]
        public required string Name { get; set; }

        /// <summary>
        /// Description of the project family.
        /// </summary>
        [JsonProperty("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Projects that belong to the project family.
        /// </summary>
        [JsonProperty("projects")]
        public required Project[] Projects { get; set; }

        /// <summary>
        /// The cover image URL of the project family.
        /// </summary>
        [JsonProperty("image_url")]
        public required Uri ImageUrl { get; set; }
    };
}
