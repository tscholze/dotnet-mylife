using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public partial class Persona
    {
        [JsonProperty("firstname")]
        public required string Firstname { get; set; }

        [JsonProperty("lastname")]
        public required string Lastname { get; set; }

        [JsonProperty("nicknames")]
        public required string[] Nicknames { get; set; }

        [JsonProperty("location_path")]
        public required string[] LocationPath { get; set; }

         [JsonProperty("languages")]
        public required string[] Languages { get; set; }

        [JsonProperty("year_of_birth")]
        public required int YearOfBirth { get; set; }

        [JsonProperty("academic_title")]
        public string? AcademicTitle  { get; set; }
    }
}
