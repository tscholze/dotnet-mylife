using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    /// <summary>
    /// Represents a software engineering project.
    /// </summary>
    public partial class Project
    {
        /// <summary>
        /// Name of the project.
        /// </summary>
        [JsonProperty("name")]
        public required string Name { get; set; }

        /// <summary>
        /// Description of the project.
        /// </summary>
        [JsonProperty("description")]
        public required string Descripton { get; set; }

        /// <summary>
        /// The cover image URL of the project.
        /// </summary>
        [JsonProperty("image_url")]
        public required Uri ImageUrl { get; set; }

        /// <summary>
        /// The GitHub URL of the project.
        /// </summary>
        [JsonProperty("github_url")]
        public required string GithubUrl { get; set; }

        /// <summary>
        /// The programming language of the project.
        /// </summary>
        [JsonProperty("programming_language")]
        public required string ProgrammingLanguage { get; set; }
    }
}
