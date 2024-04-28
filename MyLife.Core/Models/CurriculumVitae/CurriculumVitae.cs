using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    public record CurriculumVitae
    (
        [JsonProperty("current_employment")]
        Employment CurrentEmployment,

        [JsonProperty("recent_employments")]
        Employment[] RecentEmplyoments,

        [JsonProperty("educations")]
        Education[] Educations,

        [JsonProperty("publications")]
        Publication[] Publications,
        
        [JsonProperty("skillset")]
        Skillset Skillset,

        [JsonProperty("certifications")]
        Certification[] Certifications,
        
        [JsonProperty("other_interests")]
        string[] OtherInterests
    );
}
