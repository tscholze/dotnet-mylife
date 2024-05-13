using MyLife.Core.Models;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Services;
using Newtonsoft.Json;

namespace MyLife.Core;

/// <summary>
/// Life exporter.
/// </summary>
public static class Exporter
{
    #region Public exporters

    /// <summary>
    /// Export a life to a JSON string.
    /// </summary>
    /// <param name="life">Life to convert</param>
    /// <returns>Resulting JSON string</returns>
    public static string ExportLife(Life life)
    {
        return JsonConvert.SerializeObject(life);
    }

    /// <summary>
    /// Export the latest publications of content feedable content creation accounts.
    /// </summary>
    /// <param name="contentCreation">Container of accounts that shall be used.</param>
    /// <returns>Resulting JSON string</returns>
    public static async Task<string> ExportPublicationsAsync(Models.ContentCreation.Container contentCreation)
    {
        var mediumService = new MediumService();
        var accountPublications = new List<AccountPuplications>();

        foreach (var account in contentCreation.Accounts)
        {
            var publications = new List<Publication>();

            switch (account.Platform)
            {
                case Models.Shared.Platform.Youtube:
                    publications = await YouTubeService.LoadPublicationsAsync(account.Handle);
                    break;

                case Models.Shared.Platform.Medium:
                    publications = await mediumService.LoadPublicationsAsync(account.Handle);
                    break;

                default:
                    Console.WriteLine($"Platform feed loadingnot supported, the following account will be ignored: '{account.Handle}' on '{account.Platform}'");
                    break;
            }

            var accountPuplications = new AccountPuplications
            {
                Account = account,
                Publications = publications
            };

            accountPublications.Add(accountPuplications);
        }

        return JsonConvert.SerializeObject(accountPublications);
    }

    #endregion
}
