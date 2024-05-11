using Newtonsoft.Json;

namespace MyLife.Core.Models.ContentCreation
{
    /// <summary>
    /// Represents a wrapping container of content creation activities.
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// The tag (punch) line of the person's content creation activities.
        /// </summary>
        [JsonProperty("introduction_paragraphs")]
        public required string[] MotivationParagraphs { get; set; }

        /// <summary>
        /// List of content creation accounts.
        /// </summary>
        [JsonProperty("accounts")]
        public required Account[] Accounts { get; set; } 
    }
}
