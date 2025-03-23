using MyLife.Core.Models.ContentCreation;
using System.Xml.Serialization;

namespace MyLife.Core.Services
{
    /// <summary>
    /// A service to load publications from a YouTube channel.
    /// 
    /// Do not use it in a WASM-based context.
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
            try
            {
                var feedXml = await FetchFeedXmlAsync(channelId);
                var feed = DeserializeFeed(feedXml, channelId);
                return feed?.Entries.Select(MapEntryToPublication).ToList() ?? new List<Publication>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading publications for channel '{channelId}': {ex.Message}");
                return new List<Publication>();
            }
        }

        private static async Task<string> FetchFeedXmlAsync(string channelId)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://www.youtube.com/feeds/videos.xml?channel_id={channelId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static Feed? DeserializeFeed(string feedXml, string channelId)
        {
            var serializer = new XmlSerializer(typeof(Feed));
            using var reader = new StringReader(feedXml);
            if (serializer.Deserialize(reader) is not Feed feed)
            {
                Console.WriteLine($"Failed to deserialize feed for channel '{channelId}'");
                return null;
            }
            return feed;
        }

        private static Publication MapEntryToPublication(Entry entry)
        {
            return new Publication
            {
                Title = entry.MediaGroup.Title,
                Description = entry.MediaGroup.Description,
                Url = entry.Link.Href,
                ImageUrl = entry.MediaGroup.Thumbnail.Url
            };
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
