using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyLife.Core.Models.Shared
{
    /// <summary>
    /// Human language.
    /// Do not mix with a programming language.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        /// <summary>
        /// English language.
        /// </summary>
        [EnumMember(Value = "en")]
        English,

        /// <summary>
        /// German language.
        /// </summary>
        [EnumMember(Value = "de")]
        German,

        /// <summary>
        /// English and German languages (mixed).
        /// </summary>
        [EnumMember(Value = "ende")]
        EnglishAndGerman
    }
}
