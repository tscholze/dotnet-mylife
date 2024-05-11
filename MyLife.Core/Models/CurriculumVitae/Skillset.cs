using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    /// <summary>
    /// Represents a skillset of a person.
    /// </summary>
    public partial class Skillset
    {
        /// <summary>
        /// List of programming languages the person knows.
        /// </summary>
        [JsonProperty("programming_languages")]
        public required string[] ProgrammingLanguages { get; set; }

        /// <summary>
        /// List of product lifecycle tooling the person knows.
        /// </summary>
        [JsonProperty("product_lifecycle_tooling")]
        public required string[] ProductLifecycleTooling { get; set; }

        /// <summary>
        /// List of development environments (IDEs, Editors, etc.) the person knows.
        /// </summary>
        [JsonProperty("development_environments")]
        public required string[] DevelopmentEnvironments { get; set; }

        /// <summary>
        /// List of design environments (Tools, Services) the person knows.
        /// </summary>
        [JsonProperty("design_environments")]
        public required string[] DesignEnvironments { get; set; }

        /// <summary>
        /// List of design guidelines the person knows.
        /// </summary>
        [JsonProperty("design_guidelines")]
        public required string[] DesignGuidelines { get; set; }

        /// <summary>
        /// List of softskills the person has.
        /// </summary>
        [JsonProperty("soft_skills")]
        public required string[] SoftSkills { get; set; }
    }
}
