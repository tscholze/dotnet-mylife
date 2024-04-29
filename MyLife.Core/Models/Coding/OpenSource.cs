using MyLife.Core.Models.Coding;
using Newtonsoft.Json;

namespace MyLife.Core;

public partial class OpenSource
{
    [JsonProperty("tag_line")]
    public required string TagLine { get; set; }

    [JsonProperty("motivation")]
    public required string Motivation { get; set; }

    [JsonProperty("github_username")]
    public required string GitHubUsername { get; set; }

    [JsonProperty("github_profile_url")]
    public required Uri GitHubUrl { get; set; }

    [JsonProperty("project_families")]
    public required ProjectFamily[] ProjectFamilies { get; set; }
}
