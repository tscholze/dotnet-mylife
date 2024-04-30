using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Skillset
    {
         [JsonProperty("programming_languages")]
         public required string[] ProgrammingLanguages { get; set; }

         [JsonProperty("product_lifecycle_tooling")]
         public required string[] ProductLifecycleTooling { get; set; }

         [JsonProperty("development_environments")]
         public required string[] DevelopmentEnvironments { get; set; }
         
         [JsonProperty("design_environments")]
         public required string[] DesignEnvironments { get; set; }

        [JsonProperty("design_guidelines")]
        public required string[] DesignGuidelines { get; set; }

        [JsonProperty("soft_skills")]
         public required string[] SoftSkills { get; set; }
    }
}
