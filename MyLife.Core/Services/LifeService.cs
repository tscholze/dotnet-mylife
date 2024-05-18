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
        private List<MyLife.Core.Models.ContentCreation.AccountPuplications>? contentPublications = null;

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
            cachedLife ??= await FetchLifeFromServer();
            return cachedLife;
        }

        public async Task<List<AccountPuplications>?> GetContentPublications()
        {
            contentPublications ??= await FetchContentPublicationsFromServer();
            return contentPublications;
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Fetches the life information from a remote server.
        /// 
        /// If the services is mocked, it will return a sample data.
        /// </summary>
        /// <returns>The fetched life information.</returns>
        private async Task<Life?> FetchLifeFromServer()
        {
            if (mocked)
            {
                return SampleGenerators.GenerateLife();
            }

            var json = await httpClient.GetStringAsync(Constants.LifeJsonPath);
            return JsonConvert.DeserializeObject<Life>(json);
        }

        private async Task<List<AccountPuplications>?> FetchContentPublicationsFromServer()
        {
            if (mocked)
            {
                return [];
            }

            var json = await httpClient.GetStringAsync(Constants.ContentCreationPublicationsPath);
            return JsonConvert.DeserializeObject<List<AccountPuplications>>(json);
        }

        #endregion
    }
}
