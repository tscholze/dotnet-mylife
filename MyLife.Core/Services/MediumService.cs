using CodeHollow.FeedReader;
using MyLife.Core.Extensions;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.Medium;

namespace MyLife.Core.Services
{
    /// <summary>
    /// Represents a medium service to load feeds with
    /// articles.
    /// 
    /// Do not use it in a WASM-based context.
    /// </summary>
    public class MediumService(HttpClient httpClient)
    {
        #region Private members 

        private Dictionary<string, MediumFeedModel> cachedFeeds = new Dictionary<string, MediumFeedModel>();

        #endregion

        #region Public methods 

        /// <summary>
        /// Gets feeds by usernames.
        /// </summary>
        /// <param name="usernames"></param>
        /// <returns>Dictionary if handle to feed.</returns>
        public async Task<Dictionary<string, MediumFeedModel>> GetFeedsByUsernames(IEnumerable<string> usernames)
        {
            if (cachedFeeds.Any())
            {
                return cachedFeeds;
            }

            cachedFeeds = await ReadFeedsAsync(usernames);
            return cachedFeeds;
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
            }).ToList() ?? new();
        }

        #endregion

        #region Private methods
        
        private async Task<MediumFeedModel?> ReadFeedFromHandleAsync(string handle)
        {
            try
            {
                var feedUrl = $"https://{handle}.medium.com/feed";
                using var response = await httpClient.GetAsync(feedUrl);
                response.EnsureSuccessStatusCode();

                var content = (await response.Content.ReadAsStringAsync()).Trim();
                var feed = FeedReader.ReadFromString(content);
                return Convert(feed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading feed from handle '{handle}': {ex.Message}");
                return null;
            }
        }

        private async Task<Dictionary<string, MediumFeedModel>> ReadFeedsAsync(IEnumerable<string> usernames)
        {
            var fetchedFeeds = new Dictionary<string, MediumFeedModel>();

            foreach (var username in usernames)
            {
                if (await ReadFeedFromUsernameAsync(username) is { } feed)
                {
                    fetchedFeeds[username] = feed;
                }
            }

            return fetchedFeeds;
        }

        private async Task<MediumFeedModel?> ReadFeedFromUsernameAsync(string username)
        {
            try
            {
                var feedUrl = $"https://{username}.medium.com/feed";
                using var response = await httpClient.GetAsync(feedUrl);
                response.EnsureSuccessStatusCode();

                var content = (await response.Content.ReadAsStringAsync()).Trim();
                var feed = FeedReader.ReadFromString(content);
                return Convert(feed);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading feed from username '{username}': {ex.Message}");
                return null;
            }
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
            var abstractContent = content.RemoveHtmlTags();
            return abstractContent.Length <= maxLength ? abstractContent : $"{abstractContent[..maxLength]}...";
        }

        private static Uri ExtractCoverImageUriFromContent(string content)
        {
            var url = content.ExtractFirstImageUrlFromHtml() ?? "";
            return new Uri(url);
        }

        #endregion
    }
}
