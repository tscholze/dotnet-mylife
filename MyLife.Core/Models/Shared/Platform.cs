

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyLife.Core.Models.Shared
{
    /// <summary>
    /// Defines the platform of a social media account.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Platform
    {
        /// <summary>
        /// The platform is Twitter / X.
        /// </summary>
        [EnumMember(Value = "twitter")]
        Twitter,

        /// <summary>
        /// The platform is Mastodon / Fediverse
        /// </summary>
        [EnumMember(Value = "mastodon")]
        Mastodon,

        /// <summary>
        /// The platform is YouTube.
        /// </summary>
        [EnumMember(Value = "youtube")]
        Youtube,

        /// <summary>
        /// The platform is Instagram.
        /// </summary>
        [EnumMember(Value = "instagram")]
        Instagram,

        /// <summary>
        /// The platform is TikTok.
        /// </summary>
        [EnumMember(Value = "tiktok")]
        Tiktok,

        /// <summary>
        /// The platform is LinkedIn.
        /// </summary>
        [EnumMember(Value = "linkedin")]
        Linkedin,

        /// <summary>
        /// The platform is public GitHub.
        /// </summary>
        [EnumMember(Value = "github")]
        GitHub,

        /// <summary>
        /// The platform is a personal website.
        /// </summary>
        [EnumMember(Value = "blog")]
        Blog,

        /// <summary>
        /// The platform is a news website.
        /// </summary>
        [EnumMember(Value = "news")]
        News,

        /// <summary>
        /// The platform is Medium.
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,

        /// <summary>
        /// The platform is a podcast.
        /// </summary>
        [EnumMember(Value = "podcast")]
        Podcast
    }
}
