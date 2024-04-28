using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    public partial class Project
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Descripton { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("github_url")]
        public string GithubUrl { get; set; }

        [JsonProperty("programming_language")]
        public string ProgrammingLanguage { get; set; }
    }
}
