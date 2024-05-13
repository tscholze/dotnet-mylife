using Newtonsoft.Json;

namespace MyLife.Core.Models.ContentCreation
{
    /// <summary>
    /// A web publication of a content creation account.
    /// </summary>
    public partial class Publication
    {
        /// <summary>
        /// Title of the publication.
        /// </summary>
        [JsonProperty("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Description of the publication.
        /// </summary>
        [JsonProperty("description")]
        public required string Description { get; set; }

        /// <summary>
        /// Url to the publication.
        /// </summary>
        [JsonProperty("url")]
        public required string Url { get; set; }

        /// <summary>
        /// Url to the cover image of the publication.
        /// </summary>
        [JsonProperty("image_url")]
        public required string ImageUrl { get; set; }
 
    }
}
