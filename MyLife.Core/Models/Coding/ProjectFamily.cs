using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    public partial class ProjectFamily
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("description")]
        public required string Description { get; set; }

        [JsonProperty("projects")]
        public required Project[] Projects { get; set; }

        [JsonProperty("image_url")]
        public required Uri ImageUrl { get; set; }
    };
}
