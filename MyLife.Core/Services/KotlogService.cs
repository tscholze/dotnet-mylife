using CodeHollow.FeedReader;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.External;
using Newtonsoft.Json;

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
        }).ToList() ?? [];
    }
    
    #endregion
    
    #region Private methods

    private async Task<Dictionary<string, KotlogFeedModel>> ReadFeedsAsync(IEnumerable<string> blogUrls)
    {
        // Helper property for fetched feeds
        Dictionary<string, KotlogFeedModel> fetchedFeeds = [];

        // Iterate over all sources and fetch them
        foreach (var blogUrl in blogUrls)
        {
            var feed = await ReadFeedFromFeedUrlAsync(blogUrl);
            if (feed != null)
            {
                fetchedFeeds[blogUrl] = feed;
            }
        }

        // Return all successfully fetched feeds.
        return fetchedFeeds;
    }
    
    private async Task<KotlogFeedModel?> ReadFeedFromFeedUrlAsync(string blogUrl)
    {
        var feedUrl = blogUrl + "posts.json";
        using var response = await httpClient.GetAsync(feedUrl);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Failed with error code: ${response.StatusCode}");
            return null;
        }

        var json = await httpClient.GetStringAsync(feedUrl);
        var items = JsonConvert.DeserializeObject<List<KotlogItemModel>>(json);

        if (items == null || items.Count == 0)
        {
            Console.WriteLine($"Skipping feed '{feedUrl}' as it has no items.");
            return null;
        }
        
        return new KotlogFeedModel(DateTimeOffset.Now, feedUrl, items.ToArray());
    }
    
    #endregion
}