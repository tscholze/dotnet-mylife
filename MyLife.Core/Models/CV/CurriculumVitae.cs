using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class CurriculumVitae
    {
        [JsonProperty("current_employment")]
        public required Employment CurrentEmployment { get; set; }
    
        [JsonProperty("recent_employments")]
        public required Employment[] RecentEmployments { get; set; }

        [JsonProperty("educations")]
        public required Education[] Educations { get; set; }

        [JsonProperty("publications")]
        public required Publication[] Publications { get; set; }

        [JsonProperty("activities")]
        public required string[] Activities { get; set; }

        [JsonProperty("skillset")]
        public required Skillset Skillset { get; set; }

        [JsonProperty("other_interests")]
        public required string[] OtherInterests { get; set; }
    }
}
