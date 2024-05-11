using Newtonsoft.Json;

namespace MyLife.Core.Models.OpenSource;

/// <summary>
/// Represents a person's open source activities.
/// </summary>
public partial class Container
{
    /// <summary>
    /// The tag (punch) line of the person's open source activities.
    /// </summary>
    [JsonProperty("tag_line")]
    public required string TagLine { get; set; }

    /// <summary>
    /// Free form text about the person's motivation to contribute to open source.
    /// </summary>
    [JsonProperty("motivation")]
    public required string Motivation { get; set; }

    /// <summary>
    /// The username of the person on GitHub.
    /// </summary>
    [JsonProperty("github_username")]
    public required string GitHubUsername { get; set; }

    /// <summary>
    /// The URL of the person's GitHub profile.
    /// </summary>
    [JsonProperty("github_profile_url")]
    public required Uri GitHubUrl { get; set; }

    /// <summary>
    /// List of project families the person is involved in.
    /// </summary>
    [JsonProperty("project_families")]
    public required ProjectFamily[] ProjectFamilies { get; set; }
}
