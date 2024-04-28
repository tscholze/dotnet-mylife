using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record Skillset
    (
         [JsonProperty("programming_languages")]
         string[] ProgrammingLanguages,

         [JsonProperty("product_lifecycle_tooling")]
         string[] ProductLifecycleTooling,

         [JsonProperty("development_environments")]
         string[] DevelopmentEnvironments,
         
         [JsonProperty("designt_environments")]
         string[] DesignEnvironments,
        
         [JsonProperty("soft_skills")]
         string[] SoftSkills
    );
}
