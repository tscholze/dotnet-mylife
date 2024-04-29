using MyLife.Core.Models;
using MyLife.Core.Models.CV;
using MyLife.Core.Models.Shared;

namespace MyLife.Blazor.Wasm.Extensions
{
    public static class ModelToUiExtensions
    {
        public static string GetOnlyYearJoined(this Employment employment)
        {
            return employment.Joined.Split('-')[1];
        }

        public static string? GetOnlyYearLeft(this Employment employment)
        {
            if (employment.Left == null) return null;
            return employment.Left.Split('-')[1];
        }

        public static string GetIconLinkElement(this SocialMedia profile)
        {
            string icon;

            switch (profile.Platform)
            {
                case Platform.Twitter:
                    icon = "fa-twitter";
                    break;
                case Platform.Mastodon:
                    icon = "fa-mastodon";
                    break;
                case Platform.GitHub:
                    icon = "fa-github";
                    break;
                case Platform.Youtube:
                    icon = "fa-youtube";
                    break;
                case Platform.Linkedin:
                    icon = "fa-linkedin";
                    break;
                default:
                    icon = "fa-question";
                    break;
            }

            return $"<a href=\"{profile.Url}\" title=\"{profile.Platform} @{profile.Username}\" target=\"_blank\"><i class=\"fab {icon}\"></i></a>";
        }
    }
}
