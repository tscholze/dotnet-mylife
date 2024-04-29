

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyLife.Core.Models.Shared
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Platform
    {
        [EnumMember(Value = "twitter")]
        Twitter,

        [EnumMember(Value = "mastodon")]
        Mastodon,

        [EnumMember(Value = "youtube")]
        Youtube,

        [EnumMember(Value = "instagram")]
        Instagram,

        [EnumMember(Value = "tiktok")]
        Tiktok,

        [EnumMember(Value = "linkedin")]
        Linkedin,

        [EnumMember(Value = "github")]
        GitHub,

        [EnumMember(Value = "blog")]
        Blog,

        [EnumMember(Value = "news")]
        News,

        [EnumMember(Value = "medium")]
        Medium,

        [EnumMember(Value = "podcast")]
        Podcast
    }
}
