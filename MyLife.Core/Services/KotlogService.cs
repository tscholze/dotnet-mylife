using CodeHollow.FeedReader;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.External;
using Newtonsoft.Json;
using System.Text;

namespace MyLife.Core.Services;

public class KotlogService(HttpClient httpClient)
{
    #region Private members 

    private Dictionary<string, KotlogFeedModel> cachedFeeds = [];

    #endregion
    
    #region Public methods 

    /// <summary>
    /// Gets feeds by usernames.
    /// </summary>
    /// <param name="blogUrls"></param>
    /// <returns>Dictionary if handle to feed.</returns>
    public async Task<Dictionary<string, KotlogFeedModel>> GetFeedsByUsernames(IEnumerable<string> blogUrls)
    {
        // If feeds are already cached, return them.
        if (cachedFeeds.Count != 0)
        {
            return cachedFeeds;
        }

        // Else read, cache and return feeds.
        cachedFeeds = await ReadFeedsAsync(blogUrls);
        return cachedFeeds;
    }
    
    /// <summary>
    /// Loads publications from a Kotlog blog url.
    /// </summary>
    /// <param name="blogUrl">Kotlog's blog base url</param>
    /// <returns>List of found Kotlog articles or empty list.</returns>
    public async Task<List<Publication>> LoadPublicationsAsync(string blogUrl)
    {
        var feed = await ReadFeedFromFeedUrlAsync(blogUrl);
        return feed?.Items.Select(item => new Publication
        {
            Title = item.Title,
            Description = "",
            Url = item.Url.ToString(),
            ImageUrl = item.CoverImageUrl.ToString()
        }).ToList() ?? new List<Publication>();
    }
    
    #endregion
    
    #region Private methods

    /// <summary>
    /// Reads feeds from the given blog URLs.
    /// </summary>
    /// <param name="blogUrls">The blog URLs to read feeds from.</param>
    /// <returns>A dictionary of blog URLs and their corresponding feeds.</returns>
    private async Task<Dictionary<string, KotlogFeedModel>> ReadFeedsAsync(IEnumerable<string> blogUrls)
    {
        var fetchedFeeds = new Dictionary<string, KotlogFeedModel>();

        foreach (var blogUrl in blogUrls)
        {
            var feed = await ReadFeedFromFeedUrlAsync(blogUrl);
            if (feed != null)
            {
                fetchedFeeds[blogUrl] = feed;
            }
        }

        return fetchedFeeds;
    }
    
    /// <summary>
    /// Reads a feed from the given blog URL.
    /// </summary>
    /// <param name="blogUrl">The blog URL to read the feed from.</param>
    /// <returns>The feed model or null if an error occurs.</returns>
    private async Task<KotlogFeedModel?> ReadFeedFromFeedUrlAsync(string blogUrl)
    {
        try
        {
            var feedUrl = BuildFeedUrl(blogUrl);
            using var response = await httpClient.GetAsync(feedUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<KotlogItemModel>>(json);

            if (items == null || items.Count == 0)
            {
                Console.WriteLine($"Skipping feed '{feedUrl}' as it has no items.");
                return null;
            }

            return new KotlogFeedModel(DateTimeOffset.Now, feedUrl, items.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading feed from URL '{blogUrl}': {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Builds the feed URL from the given blog URL.
    /// </summary>
    /// <param name="blogUrl">The blog URL to build the feed URL from.</param>
    /// <returns>The constructed feed URL.</returns>
    private string BuildFeedUrl(string blogUrl)
    {
        return new StringBuilder(blogUrl).Append("posts.json").ToString();
    }
    
    #endregion
}