using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Certification
    {
        [JsonProperty("title")]
        public required string Title { get; set; }

        [JsonProperty("description")]
        public required string Description { get; set; }

        [JsonProperty("instituation")]
        public required string? Instituation { get; set; }
    }
}
