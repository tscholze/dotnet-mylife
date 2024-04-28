using MyLife.Core.Models.Coding;
using Newtonsoft.Json;

namespace MyLife.Core;

public partial class OpenSource
{
    [JsonProperty("github_username")]
    public string GitHubUsername { get; set; }

    [JsonProperty("github_profile_url")]
    public Uri GitHubUrl { get; set; }

    [JsonProperty("project_families")]
    public ProjectFamily[] ProjectFamilies { get; set; }
}
