using Newtonsoft.Json;

namespace MyLife.Core.Models.Persona
{
    /// <summary>
    /// Represents generic personal information.
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// First name of the person.
        /// </summary>
        [JsonProperty("firstname")]
        public required string Firstname { get; set; }

        /// <summary>
        /// Last name of the person.
        /// </summary>
        [JsonProperty("lastname")]
        public required string Lastname { get; set; }

        /// <summary>
        /// List of nicknames of the person.
        /// </summary>
        [JsonProperty("nicknames")]
        public required string[] Nicknames { get; set; }

        /// <summary>
        /// Location path of the person.
        /// E.g.: Country, State, City
        /// </summary>
        [JsonProperty("location_path")]
        public required string[] LocationPath { get; set; }

        /// <summary>
        /// List of avatar image URLs.
        /// </summary>
        [JsonProperty("avatar_image_urls")]
        public required string[] AvatarImageUrls { get; set; }

        /// <summary>
        /// List of languages the person speaks.
        /// </summary>
        [JsonProperty("languages")]
        public required string[] Languages { get; set; }

        /// <summary>
        /// Year of birth of the person.
        /// </summary>
        [JsonProperty("year_of_birth")]
        public required int YearOfBirth { get; set; }

        /// <summary>
        /// List of paragraphs that introduce the person.
        /// </summary>
        [JsonProperty("introduction_paragraphs")]
        public required string[] IntroductionParagraphs { get; set; }

        /// <summary>
        /// Optional academic title of the person.
        /// </summary>
        [JsonProperty("academic_title")]
        public string? AcademicTitle { get; set; }
    }
}
