using MyLife.Core.Models.CurriculumVitae;
using MyLife.Core.Models.Shared;

namespace MyLife.Blazor.Wasm.Extensions
{
    /// <summary>
    /// Extension methods for converting model data to UI-friendly formats.
    /// </summary>
    public static class ModelToUiExtensions
    {
        /// <summary>
        /// Gets the year of joining.
        /// </summary>
        /// <param name="employment">Data source</param>
        /// <returns>Year of joining</returns>
        public static string GetOnlyYearJoined(this Employment employment)
        {
            ArgumentNullException.ThrowIfNull(employment);
            ArgumentException.ThrowIfNullOrEmpty(employment.Joined);

            return employment.Joined.Split('-')[1];
        }

        /// <summary>
        /// Gets the year of leaving.
        /// </summary>
        /// <param name="employment">Data source</param>
        /// <returns>Year of leaving or null</returns>
        public static string? GetOnlyYearLeft(this Employment employment)
        {
            ArgumentNullException.ThrowIfNull(employment);
            
            if (employment.Left == null) return null;
            return employment.Left.Split('-')[1];
        }

        /// <summary>
        /// Gets a HTML element with the icon of the social media platform.
        /// </summary>
        /// <param name="account">Data source</param>
        /// <returns>Html element</returns>
        public static string GetIconLinkElement(this Core.Models.SocialMedia.Account account)
        {
            ArgumentNullException.ThrowIfNull(account);
            ArgumentNullException.ThrowIfNull(account.Url);
            ArgumentException.ThrowIfNullOrEmpty(account.Username);

            try
            {
                string icon = account.Platform switch
                {
                    Platform.Twitter => "fa-twitter",
                    Platform.Mastodon => "fa-mastodon",
                    Platform.GitHub => "fa-github",
                    Platform.Youtube => "fa-youtube",
                    Platform.Linkedin => "fa-linkedin",
                    Platform.Instagram => "fa-instagram",
                    Platform.Tiktok => "fa-tiktok",
                    Platform.WordPress or Platform.Kotlog => "fa-rss",
                    Platform.News => "fa-newspaper",
                    Platform.Medium => "fa-medium",
                    Platform.Podcast => "fa-podcast",
                    _ => "fa-question"
                };

                return $"""<a href="{account.Url}" title="{account.Platform} @{account.Username}" target="_blank" rel="noopener noreferrer"><i class="fab {icon}"></i></a>""";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to create icon link for {account.Platform}", ex);
            }
        }
    }
}
