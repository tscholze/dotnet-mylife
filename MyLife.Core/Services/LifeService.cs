using MyLife.Core.Generator;
using MyLife.Core.Models;
using Newtonsoft.Json;

namespace MyLife.Core.Services
{
    /// <summary>
    /// Represents a service to load life information.
    /// </summary>
    /// <param name="httpClient">The HttpClient to use for fetching the life information.</param>
    /// <param name="useRemote">If true, the life.jsopn from remote /wwwroot will be used. Elsewise sample data.</param>
    public class LifeService(HttpClient httpClient, bool useRemote = true)
    {
        #region Private member

        private Life? cachedLife = null;

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

        /// <summary>
        /// Fetches the life information from a remote server.
        /// </summary>
        /// <returns>The fetched life information.</returns>
        private async Task<Life?> FetchLifeFromServer()
        {
            if (useRemote)
            {
                var json = await httpClient.GetStringAsync("data/life.json");
                cachedLife = JsonConvert.DeserializeObject<Life>(json);
                return cachedLife;
            }

            return SampleGenerators.GenerateLife();
        }

        #endregion
    }
}
