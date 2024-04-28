using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class CurriculumVitae
    {
        [JsonProperty("current_employment")]
        public Employment CurrentEmployment { get; set; }
    
        [JsonProperty("recent_employments")]
        public Employment[] RecentEmployments { get; set; }

        [JsonProperty("educations")]
        public Education[] Educations { get; set; }

        [JsonProperty("publications")]
        public Publication[] Publications { get; set; }

        [JsonProperty("activities")]
        public string[] Activities { get; set; }

        [JsonProperty("skillset")]
        public Skillset Skillset { get; set; }

        [JsonProperty("other_interests")]
        public string[] OtherInterests { get; set; }
    }
}
