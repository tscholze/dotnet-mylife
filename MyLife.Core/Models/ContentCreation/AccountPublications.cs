using Newtonsoft.Json;

namespace MyLife.Core.Models.ContentCreation
{
    /// <summary>
    /// Container for a content creation account and its publications.
    /// </summary>
    public partial class AccountPublications
    {
        /// <summary>
        /// Account on a content creation platform.
        /// </summary>
        [JsonProperty("account")]
        public required Account Account { get; set; }

        /// <summary>
        /// List of publications of the account.
        /// </summary>
        [JsonProperty("publications")]
        public required IEnumerable<Publication> Publications { get; set; }
    }
}
