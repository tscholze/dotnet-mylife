using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
 public partial class Education
    {
        [JsonProperty("institution")]
        public string Instituation { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("graduation")]
        public string Graduation { get; set; }

       [JsonProperty("year_of_graduation")]
        public int YearOfGraduation { get; set; }
    }       
}
