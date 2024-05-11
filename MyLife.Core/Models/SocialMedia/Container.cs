using Newtonsoft.Json;

namespace MyLife.Core.Models.SocialMedia
{
    /// <summary>
    /// Represents a wrapping container of social media activities.
    /// </summary>
    public partial class Container
    {
        /// <summary>
        /// The tag (punch) line of the person's social media activities.
        /// </summary>
        [JsonProperty("introduction_paragraphs")]
        public required string[] MotivationParagraphs { get; set; }

        /// <summary>
        /// List of social media accounts.
        /// </summary>
        public required Account[] Accounts { get; set; }
    }
}