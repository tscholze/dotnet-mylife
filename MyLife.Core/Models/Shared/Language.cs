using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyLife.Core.Models.Shared
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        [EnumMember(Value = "en")]
        English,
        [EnumMember(Value = "de")]
        German,
        [EnumMember(Value = "ende")]
        EnglishAndGerman
    }
}
