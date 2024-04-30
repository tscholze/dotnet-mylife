using MyLife.Core.Models.Shared;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    /// <summary>
    /// Represents a content creation profile.
    /// </summary>
    public partial class ContentCreation
    {
        /// <summary>
        /// Name of the content creation profile.
        /// </summary>
        [JsonProperty("name")]
        public required string Name { get; set; }

        /// <summary>
        /// The platform of the content creation profile.
        /// </summary>
        [JsonProperty("platform")]
        public required Platform Platform { get; set; }

        /// <summary>
        /// Description of the content.
        /// </summary>
        [JsonProperty("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Language of the content.
        /// </summary>
        [JsonProperty("language")]
        public required Language Language { get; set; }

        /// <summary>
        /// The URL of the content creation profile.
        /// </summary>
        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}
