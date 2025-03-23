using MyLife.Core.Models.ContentCreation;

namespace MyLife.Core.Services;

/// <summary>
/// Defines the contract for content services that fetch publications
/// </summary>
public interface IContentService
{
    /// <summary>
    /// Loads publications for a given account identifier
    /// </summary>
    /// <param name="identifier">Account identifier (handle or URL)</param>
    /// <returns>List of publications</returns>
    Task<List<Publication>> LoadPublicationsAsync(string identifier);
}
