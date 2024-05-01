using MyLife.Core.Generator;
using MyLife.Core.Models;

namespace MyLife.Core.Services
{
    /// <summary>
    /// A service covering all aspects of a person's 
    /// life information.
    public class LifeService
    {
        #region Private member

        private readonly Life cachedLife = SampleGenerators.GenerateLife();

        #endregion

        #region Data getters

        /// <summary>
        /// Get the life information of a person.
        /// 
        /// Could be cached or fetched from a remote server.
        /// </summary>
        /// <returns>Person's life.</returns>
        public Life GetLife()
        {
            return cachedLife;
        }

        #endregion
    }


}
