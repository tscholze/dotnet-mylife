namespace MyLife.Core.Models.YouTube
{
    /// <summary>
    /// Describes a YouTube rss feed.
    /// </summary>
    public class YouTubeChannelModel
    {
        /// <summary>
        /// Title of the channel.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Description of the channel.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Link to the channel.
        /// </summary>
        public required string Link { get; set; }

        /// <summary>
        /// Author'S name of the channel.
        /// </summary>
        public required string Author { get; set; }

        /// <summary>
        /// Thumbnail url of the channel.
        /// </summary>
        public required string ThumbnailUrl { get; set; }
    }
}
