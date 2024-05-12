namespace MyLife.Core.Services
{
    public class YouTubeService
    {
        // Create a function that loads the rss feed of a youtube channel by its name
        public async Task<string> LoadRssFeedAsync(string channelName)
        {
            // Create a new HttpClient
            var client = new HttpClient();

            // Load the rss feed of the channel
            var response = await client.GetAsync($"https://www.youtube.com/feeds/videos.xml?channel_id={channelName}");


            return await response.Content.ReadAsStringAsync();
        }
    }


    // Create a model from a youtube rss feed

}
