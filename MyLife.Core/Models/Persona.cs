using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    public record Persona
    (
        [JsonProperty("firstname")]
        string Firstname,

        [JsonProperty("lastname")]
        string Lastname,

        [JsonProperty("nicknames")]
        string[] Nicknames,

        [JsonProperty("location_path")]
        string[] LocationPath,

         [JsonProperty("languages")]
        string[] Languages,

        [JsonProperty("year_of_birth")]
        int YearOfBirth,

        [JsonProperty("academic_title")]
        string? AcademicTitle
    );
}
