using CodeHollow.FeedReader;
using MyLife.Core.Extensions;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.Medium;

namespace MyLife.Core.Services
{
    /// <summary>
    /// Represents a medium service to load feeds with
    /// articles.
    /// </summary>
    public class MediumService(HttpClient httpClient)
    {
        #region Private members 

        private Dictionary<string, MediumFeedModel> cachedFeeds = [];

        #endregion

        #region Public methods 

        /// <summary>
        /// Gets feeds by usernames.
        /// </summary>
        /// <param name="usernames"></param>
        /// <returns>Dictionary if handle to feed.</returns>
        public async Task<Dictionary<string, MediumFeedModel>> GetFeedsByUsernames(IEnumerable<string> usernames)
        {
            // If feeds are already cached, return them.
            if (cachedFeeds.Count != 0)
            {
                return cachedFeeds;
            }

            // Else read, cache and return feeds.
            cachedFeeds = await ReadFeedsAsync(usernames);
            return cachedFeeds;
        }

        /// <summary>
        /// Reads a feed from a Medium handle (username).
        /// </summary>
        /// <param name="handle">Medium account handle</param>
        /// <returns>Found Medium feed or null</returns>
        public async Task<MediumFeedModel?> ReadFeedFromHandleAsync(string handle)
        {
            var feedUrl = $"https://{handle}.medium.com/feed";
            using var response = await httpClient.GetAsync(feedUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed with error code: ${response.StatusCode}");
                return null;
            }

            var content = (await response.Content.ReadAsStringAsync()).Trim();
            var feed = FeedReader.ReadFromString(content);
            return Convert(feed);
        }

        /// <summary>
        /// Loads publications from a Medium handle.
        /// </summary>
        /// <param name="handle">Medium account handle</param>
        /// <returns>List of found Medium articles or empty list.</returns>
        public async Task<List<Publication>> LoadPublicationsAsync(string handle)
        {
            var feed = await ReadFeedFromHandleAsync(handle);
            return feed?.Articles.Select(article => new Publication
            {
                Title = article.Title,
                Description = article.Abstract,
                Url = article.ArticleUri.ToString(),
                ImageUrl = article.CoverImageUri.ToString()
            }).ToList() ?? [];
        }

        #endregion

        #region Private methods

        private async Task<Dictionary<string, MediumFeedModel>> ReadFeedsAsync(IEnumerable<string> usernames)
        {
            // Helper property for fetched feeds
            Dictionary<string, MediumFeedModel> fetchedFeeds = [];

            // Iterate over all sources and fetch them
            foreach (var username in usernames)
            {
                var feed = await ReadFeedFromUsernameAsync(username);
                if (feed != null)
                {
                    fetchedFeeds[username] = feed;
                }
            }

            // Return all succesfully fetched feeds.
            return fetchedFeeds;
        }

        private async Task<MediumFeedModel?> ReadFeedFromUsernameAsync(string username)
        {
            var feedUrl = $"https://{username}.medium.com/feed";
            using var response = await httpClient.GetAsync(feedUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed with error code: ${response.StatusCode}");
                return null;
            }

            var content = (await response.Content.ReadAsStringAsync()).Trim();
            var feed = FeedReader.ReadFromString(content);
            return Convert(feed);
        }

        private static MediumFeedModel Convert(Feed feed)
        {
            return new MediumFeedModel(
                feed.Title,
                feed.LastUpdatedDate ?? DateTime.Now,
                feed.Items.Select(Convert).ToList()
            );
        }

        private static MediumArticleModel Convert(FeedItem item)
        {
            return new MediumArticleModel(
                item.Title.Trim(),
                ExtractAbstractFromContent(item.Content),
                item.PublishingDate ?? DateTime.Now,
                ExtractCoverImageUriFromContent(item.Content),
                new Uri(item.Link)
            );
        }

        private static string ExtractAbstractFromContent(string content, int maxLength = 225)
        {
            return content
                .Split("<h3>", 1)
                .First()
                .RemoveHtmlTags()
                .Truncate(maxLength);
        }

        private static Uri ExtractCoverImageUriFromContent(string content)
        {
            var url = content.ExtractFirstImageUrlFromHtml() ?? "";
            return new Uri(url);
        }

        #endregion
    }
}
