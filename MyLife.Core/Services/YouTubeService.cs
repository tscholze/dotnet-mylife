using CodeHollow.FeedReader.Feeds.MediaRSS;
using MyLife.Core.Models.ContentCreation;
using System.Xml.Serialization;

namespace MyLife.Core.Services
{
    /// <summary>
    /// A service to load publications from a YouTube channel.
    /// </summary>
    public class YouTubeService
    {
        /// <summary>
        /// Load feed from a YouTube Channel and returns it's released videos as a List of publications.
        /// </summary>
        /// <param name="channelId">Channel ID</param>
        /// <returns>List of found videos. Returns empty list if operation fails.</returns>
        public static async Task<List<Publication>> LoadPublicationsAsync(string channelId)
        {
            // Create a new HttpClient
            var client = new HttpClient();

            // Load the rss feed of the channel
            var response = await client.GetAsync($"https://www.youtube.com/feeds/videos.xml?channel_id={channelId}");
            var feedXml = await response.Content.ReadAsStringAsync();

            // Serialize the feed
            var serializer = new XmlSerializer(typeof(Feed));
            if (serializer == null)
            {
                Console.WriteLine($"Failed to create serializer for feed of channel '{channelId}'");
                return [];
            }

            if (serializer.Deserialize(new StringReader(feedXml)) is not Feed feed)
            {
                Console.WriteLine($"Failed to create serializer for feed of channel '{channelId}'");
                return [];
            }

            // Convert the feed to a list of publications
            return feed.Entries.Select(entry => new Publication
            {
                Title = entry.MediaGroup.Title,
                Description = entry.MediaGroup.Description,
                Url = entry.Link.Href,
                ImageUrl = entry.MediaGroup.Thumbnail.Url
            }).ToList();
        }

        #region Translation classes

        [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
        public class Feed
        {
            [XmlElement(ElementName = "entry")]
            public required List<Entry> Entries { get; set; }
        }

        public class Link
        {
            [XmlAttribute("href")]
            public required string Href { get; set; }
        }

        public class Entry
        {
            [XmlElement(ElementName = "link")]
            public required Link Link { get; set; }

            [XmlElement(ElementName = "group", Namespace = "http://search.yahoo.com/mrss/")]
            public required MediaGroup MediaGroup { get; set; }
        }

        public class MediaGroup
        {
            [XmlElement(ElementName = "title", Namespace = "http://search.yahoo.com/mrss/")]
            public required string Title { get; set; }

            [XmlElement(ElementName = "description", Namespace = "http://search.yahoo.com/mrss/")]
            public required string Description { get; set; }

            [XmlElement(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
            public required MediaThumbnail Thumbnail { get; set; }
        }

        public class MediaThumbnail
        {
            [XmlAttribute("url")]
            public required string Url { get; set; }
        }

        #endregion
    }
}
