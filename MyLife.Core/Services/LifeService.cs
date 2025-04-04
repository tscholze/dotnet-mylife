using MyLife.Core.Generator;
using MyLife.Core.Models;
using MyLife.Core.Models.ContentCreation;
using Newtonsoft.Json;

namespace MyLife.Core.Services
{
    /// <summary>
    /// Represents a service to load life information.
    /// Useable in a WASM-based context.
    /// </summary>
    /// <param name="httpClient">The [HttpClient] to use for fetching the life information.</param>
    /// <param name="mocked">If true, no remote data will be used. It will be replaced by SampleGenerator data.</param>
    public class LifeService(HttpClient httpClient, bool mocked = false)
    {
        #region Private member

        /// <summary>
        /// In-memory cached life information.
        /// If null, it has not been fetched yet.
        /// </summary>
        private Life? cachedLife = null;

        /// <summary>
        /// In-memory list of found content publications.
        /// If null, it has not been fetched yet.
        /// </summary>
        private List<MyLife.Core.Models.ContentCreation.AccountPublications>? contentPublications = null;

        #endregion

        #region Data getters

        /// <summary>
        /// Get the life information of a person.
        /// 
        /// Could be cached or fetched from a remote server.
        /// </summary>
        /// <returns>Person's life.</returns>
        public async Task<Life?> GetLife()
        {
            cachedLife ??= await FetchDataFromServer(Constants.LifeJsonApiPath, SampleGenerators.GenerateLife);
            return cachedLife;
        }

        /// <summary>
        /// Gets the content publications for all accounts.
        /// Could be cached or fetched from a remote server.
        /// </summary>
        /// <returns>List of account publications or null if not available.</returns>
        public async Task<List<AccountPublications>?> GetContentPublications()
        {
            contentPublications ??= await FetchDataFromServer(Constants.ContentCreationPublicationsApiPath, () => new List<AccountPublications>());
            return contentPublications;
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Fetches data from a remote server.
        /// 
        /// If the service is mocked, it will return sample data.
        /// </summary>
        /// <typeparam name="T">The type of data to fetch.</typeparam>
        /// <param name="apiPath">The API path to fetch data from.</param>
        /// <param name="mockedDataGenerator">The function to generate mocked data.</param>
        /// <returns>The fetched data.</returns>
        private async Task<T?> FetchDataFromServer<T>(string apiPath, Func<T> mockedDataGenerator)
        {
            try
            {
                if (mocked)
                {
                    return mockedDataGenerator();
                }

                var json = await httpClient.GetStringAsync(apiPath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data from server: {ex.Message}");
                return default;
            }
        }

        #endregion
    }
}
