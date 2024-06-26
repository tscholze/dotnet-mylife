﻿using Newtonsoft.Json;

namespace MyLife.Core.Models.CurriculumVitae
{
    /// <summary>
    /// Curriculum vitae of a person.
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// Current employment of the person.
        /// </summary>
        [JsonProperty("current_employment")]
        public required Employment CurrentEmployment { get; set; }

        /// <summary>
        /// Most recent employments of the person.
        /// Including the current.
        /// </summary>
        [JsonProperty("recent_employments")]
        public required Employment[] RecentEmployments { get; set; }

        /// <summary>
        /// Educational steps of the person.
        /// </summary>
        [JsonProperty("educations")]
        public required Education[] Educations { get; set; }

        /// <summary>
        /// Certifications of the person.
        /// </summary>
        [JsonProperty("certifications")]
        public required Certification[] Certifications { get; set; }

        /// <summary>
        /// Publications of the person.
        /// </summary>
        [JsonProperty("publications")]
        public required Publication[] Publications { get; set; }

        /// <summary>
        /// Hard and soft skills of the person.
        /// </summary>
        [JsonProperty("skillset")]
        public required Skillset Skillset { get; set; }

        /// <summary>
        /// Spare time activities of the person.
        /// </summary>
        [JsonProperty("activities")]
        public required string[] Activities { get; set; }

        /// <summary>
        /// Other interests of the person.
        /// </summary>
        [JsonProperty("other_interests")]
        public required string[] OtherInterests { get; set; }
    }
}
