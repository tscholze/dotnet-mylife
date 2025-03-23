using MyLife.Core.Models;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.Shared;
using MyLife.Core.Services;
using Newtonsoft.Json;

namespace MyLife.Core;

/// <summary>
/// Provides functionality to export Life data and content creation publications to JSON format.
/// </summary>
public static class Exporter
{
    #region Public exporters

    /// <summary>
    /// Exports a life instance to a JSON string.
    /// </summary>
    /// <param name="life">The Life instance to serialize</param>
    /// <returns>A JSON string representation of the Life instance</returns>
    /// <exception cref="ArgumentNullException">Thrown when life is null</exception>
    /// <exception cref="JsonSerializationException">Thrown when serialization fails</exception>
    public static string ExportLife(Life life)
    {
        if (life == null) throw new ArgumentNullException(nameof(life));
        
        try
        {
            return JsonConvert.SerializeObject(life, new JsonSerializerSettings 
            { 
                Formatting = Formatting.Indented
            });
        }
        catch (JsonSerializationException ex)
        {
            throw new JsonSerializationException($"Failed to serialize Life instance: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Exports the latest publications of content feedable content creation accounts.
    /// </summary>
    /// <param name="contentCreation">Container holding the accounts to process</param>
    /// <param name="verbose">When true, outputs progress information to console</param>
    /// <returns>A JSON string containing the exported publications</returns>
    /// <exception cref="ArgumentNullException">Thrown when contentCreation is null</exception>
    public static async Task<string> ExportPublicationsAsync(Container contentCreation, bool verbose = true)
    {
        if (contentCreation == null) throw new ArgumentNullException(nameof(contentCreation));

        var mediumService = new MediumService(new HttpClient());
        var kotlogService = new KotlogService(new HttpClient());
        var accountPublications = new List<AccountPublications>();
        var errors = new List<(string Account, string Platform, string Error)>();

        foreach (var account in contentCreation.Accounts)
        {
            if (verbose) Console.WriteLine($"Processing account: {account.Handle} on {account.Platform}");
            
            try
            {
                var publications = await LoadPublicationsForAccountAsync(account, mediumService, kotlogService);
                accountPublications.Add(new AccountPublications
                {
                    Account = account,
                    Publications = publications
                });
            }
            catch (Exception ex)
            {
                var error = $"Error: {ex.Message}";
                errors.Add((account.Handle, account.Platform.ToString(), error));
                if (verbose) Console.WriteLine(error);
            }
        }

        if (verbose)
        {
            var publicationCount = accountPublications.Sum(a => a.Publications.Count());
            Console.WriteLine($"Exported {accountPublications.Count} accounts with {publicationCount} total publications");
            if (errors.Any())
            {
                Console.WriteLine($"Encountered {errors.Count} errors during export");
            }
        }

        return JsonConvert.SerializeObject(accountPublications, Formatting.Indented);
    }

    #endregion

    #region Private helpers

    private static async Task<List<Publication>> LoadPublicationsForAccountAsync(
        Account account,
        MediumService mediumService,
        KotlogService kotlogService)
    {
        try
        {
            return account.Platform switch
            {
                Platform.Youtube => await YouTubeService.LoadPublicationsAsync(account.Handle),
                Platform.Medium => await mediumService.LoadPublicationsAsync(account.Handle),
                Platform.Kotlog => 
                    account.Url != null 
                        ? await kotlogService.LoadPublicationsAsync(account.Url.ToString())
                        : throw new ArgumentNullException(nameof(account.Url), "Account URL cannot be null for Kotlog platform"),
                _ => throw new NotSupportedException($"Platform {account.Platform} is not supported")
            };
        }
        catch (Exception ex)
        {
            // Log the error for debugging purposes
            Console.WriteLine($"Error loading publications for account {account.Handle} on {account.Platform}: {ex.Message}");
            throw; // Re-throw the exception to be handled by the caller
        }
    }

    #endregion
}