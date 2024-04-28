using Newtonsoft.Json;

namespace MyLife.Core.Models.Coding
{
    public partial class ProjectFamily
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description")]
        public Project[] Projects { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }
    };
}
