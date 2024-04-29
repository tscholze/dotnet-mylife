using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    public partial class Project
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("description")]
        public required string Descripton { get; set; }

        [JsonProperty("image_url")]
        public required Uri ImageUrl { get; set; }

        [JsonProperty("github_url")]
        public required string GithubUrl { get; set; }

        [JsonProperty("programming_language")]
        public required string ProgrammingLanguage { get; set; }
    }
}
