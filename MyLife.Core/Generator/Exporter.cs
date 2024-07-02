using MyLife.Core.Models;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.Shared;
using MyLife.Core.Services;
using Newtonsoft.Json;

namespace MyLife.Core;

/// <summary>
///     Life exporter.
/// </summary>
public static class Exporter
{
    #region Public exporters

    /// <summary>
    ///     Export a life to a JSON string.
    /// </summary>
    /// <param name="life">Life to convert</param>
    /// <returns>Resulting JSON string</returns>
    public static string ExportLife(Life life)
    {
        return JsonConvert.SerializeObject(life);
    }

    /// <summary>
    ///     Export the latest publications of content feedable content creation accounts.
    /// </summary>
    /// <param name="contentCreation">Container of accounts that shall be used.</param>
    /// <param name="verbose">If true, Console.Write will be used to inform the user what happens.</param>
    /// <returns>Resulting JSON string</returns>
    public static async Task<string> ExportPublicationsAsync(Container contentCreation, bool verbose = true)
    {
        var mediumService = new MediumService(new HttpClient());
        var kotlogService = new KotlogService(new HttpClient());
        var accountPublications = new List<AccountPublications>();

        foreach (var account in contentCreation.Accounts)
        {
            var publications = new List<Publication>();

            switch (account.Platform)
            {
                case Platform.Youtube:
                    publications = await YouTubeService.LoadPublicationsAsync(account.Handle);
                    break;

                case Platform.Medium:
                    publications = await mediumService.LoadPublicationsAsync(account.Handle);
                    break;
                case Platform.Kotlog:
                    publications = await kotlogService.LoadPublicationsAsync(account.Url.ToString());
                    break;

                default:
                    Console.WriteLine(
                        $"Platform feed loading not supported, the following account will be ignored: '{account.Handle}' on '{account.Platform}'");
                    break;
            }

            accountPublications.Add(new AccountPublications
            {
                Account = account,
                Publications = publications
            });
        }

        if (verbose)
        {
            var publicationCount = accountPublications.SelectMany(a => a.Publications).Count();

            Console.WriteLine($"""
                               Exported '{accountPublications.Count}' supported accounts with in total {publicationCount} publications.
                               """.Trim());
        }

        return JsonConvert.SerializeObject(accountPublications);
    }

    #endregion
}