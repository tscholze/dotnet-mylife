using MyLife.Core.Models;

namespace MyLife.Blazor.Wasm.Services
{
    /// <summary>
    /// A service covering all aspects of a person's 
    /// life information.
    /// </summary>
    public interface ILifeService
    {
        /// <summary>
        /// Get the life information of a person.
        /// 
        /// Could be cached or fetched from a remote server.
        /// </summary>
        /// <returns>Person's life.</returns>
        public Life GetLife();
    }
}
