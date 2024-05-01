namespace MyLife.Core.Models.Medium
{
    /// <summary>
    /// Represents a medium feed model.
    /// </summary>
    /// <param name="Title">Title of the feed (account)</param>
    /// <param name="LastChanged">Date of last content change</param>
    /// <param name="Articles">Lis tof articles of the feed</param>
    public record MediumFeedModel(string Title, DateTime LastChanged, List<MediumArticleModel> Articles);
}
