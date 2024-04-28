using Newtonsoft.Json;

namespace MyLife.Core.Models.CV
{
    public partial class Publication
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
