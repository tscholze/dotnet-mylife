using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
 public partial class Education
    {
        [JsonProperty("institution")]
        public required string Instituation { get; set; }

        [JsonProperty("content")]
        public required string[] Content { get; set; }

        [JsonProperty("graduation")]
        public required string Graduation { get; set; }

       [JsonProperty("year_of_graduation")]
        public required int YearOfGraduation { get; set; }
    }       
}
