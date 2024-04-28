using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Skillset
    {
         [JsonProperty("programming_languages")]
         public string[] ProgrammingLanguages { get; set; }

         [JsonProperty("product_lifecycle_tooling")]
         public string[] ProductLifecycleTooling { get; set; }

         [JsonProperty("development_environments")]
         public string[] DevelopmentEnvironments { get; set; }
         
         [JsonProperty("designt_environments")]
         public string[] DesignEnvironments { get; set; }
        
         [JsonProperty("soft_skills")]
         public string[] SoftSkills { get; set; }
    }
}
