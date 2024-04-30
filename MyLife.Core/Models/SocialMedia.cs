using MyLife.Core.Models.Shared;
using Newtonsoft.Json;

namespace MyLife.Core.Models
{
    /// <summary>
    /// Represents a social media account.
    /// </summary>
    public partial class SocialMedia
    {
        /// <summary>
        /// Username of the account.
        /// It does not include the '@' symbol.
        /// </summary>
        [JsonProperty("username")]
        public required string Username { get; set; }

        /// <summary>
        /// The platform of the account.
        /// </summary>
        [JsonProperty("platform")]
        public required Platform Platform { get; set; }

        /// <summary>
        /// The URL of the account.
        /// </summary>
        [JsonProperty("profile_url")]
        public required Uri Url { get; set; }
    }
}