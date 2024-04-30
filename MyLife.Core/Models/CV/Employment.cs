using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    /// <summary>
    /// Represents an employment of a person.
    /// </summary>
    public partial class Employment {
        /// <summary>
        /// Name of the company.
        /// </summary>
        [JsonProperty("company")]
        public required string Company { get; set; }

        /// <summary>
        /// Role of the person in the company.
        /// </summary>
        [JsonProperty("role")]
        public required string Role { get; set; }

        /// <summary>
        /// Tasks and responsibilities the person had in the company.
        /// </summary>
        [JsonProperty("tasks")]
        public required string[] Tasks { get; set; }

        /// <summary>
        /// The date the person joined the company.
        /// </summary>
        [JsonProperty("joined")]
        public required string Joined { get; set; }

        /// <summary>
        /// The date the person left the company.
        /// If null, the person is still working there.
        /// </summary>
        [JsonProperty("left")]
        public required string? Left { get; set; }
    }

}
