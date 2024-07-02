using Newtonsoft.Json;

namespace MyLife.Core.Models.External;

public class KotlogItemModel
{
    [JsonProperty("title")]
    public required string Title { get; set; }

    [JsonProperty("primaryTag")]
    public string? PrimaryTag { get; set; }

    [JsonProperty("created")]
    public required DateTimeOffset Created { get; set; }

    [JsonProperty("url")]
    public required Uri Url { get; set; }

    [JsonProperty("coverImageUrl")]
    public required Uri CoverImageUrl { get; set; }
}