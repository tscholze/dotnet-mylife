using MyLife.Core.Generator;
using MyLife.Core.Models;

namespace MyLife.Blazor.Wasm.Services
{
    /// <summary>
    /// A service implementation covering all aspects of a person's life.
    /// </summary>
    public class LifeService : ILifeService
    {
        #region Private member

        private readonly Life cachedLife = SampleGenerators.GenerateLife();

        #endregion

        #region ILifeService implementation

        public Life GetLife()
        {
            return cachedLife;
        }

        #endregion
    }


}
