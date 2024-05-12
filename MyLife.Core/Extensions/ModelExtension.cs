
namespace MyLife.Core.Extensions
{
    /// <summary>
    /// Summary of model extension.
    /// </summary>
    public static class ModelExtension
    {
        #region Persona extensions

        /// <summary>
        /// Get the full name of a person.
        /// If one of the names is empty, it will be ignored.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Full name</returns>
        public static string GetFullname(this Models.Persona.Container persona)
        {
            List<string> names =
            [
                persona.Firstname.Trim(),
                persona.Lastname.Trim()
            ];


            return string.Join(" ", names.Where(n => n != ""));
        }

        #endregion

        #region ContentCreation.Account extensions

        /// <summary>
        /// Gets all Medium accounts from list.
        /// </summary>
        /// <param name="accounts">List of all accounts</param>
        /// <returns>Medium accounts</returns>
        public static IEnumerable<Models.ContentCreation.Account> GetMediumAccounts(this IEnumerable<Models.ContentCreation.Account> accounts)
        {
            return accounts.Where(a => a.Platform == Models.Shared.Platform.Medium);
        }

        /// <summary>
        /// Gets all Youtube accounts from list.
        /// </summary>
        /// <param name="accounts">List of all accounts</param>
        /// <returns>Youtube accounts</returns>
        public static IEnumerable<Models.ContentCreation.Account> GetYouTubeAccounts(this IEnumerable<Models.ContentCreation.Account> accounts)
        {
            return accounts.Where(a => a.Platform == Models.Shared.Platform.Youtube);
        }

        /// <summary>
        /// Gets all TikTok accounts from list.
        /// </summary>
        /// <param name="accounts">List of all accounts</param>
        /// <returns>TikTok accounts</returns>
        public static IEnumerable<Models.ContentCreation.Account> GetTikTokAccounts(this IEnumerable<Models.ContentCreation.Account> accounts)
        {
            return accounts.Where(a => a.Platform == Models.Shared.Platform.Tiktok);
        }

        /// <summary>
        /// Gets all Instagram accounts from list.
        /// </summary>
        /// <param name="accounts">List of all accounts</param>
        /// <returns>Instagram accounts</returns>
        public static IEnumerable<Models.ContentCreation.Account> GetInstagramAccounts(this IEnumerable<Models.ContentCreation.Account> accounts)
        {
            return accounts.Where(a => a.Platform == Models.Shared.Platform.Instagram);
        }

        #endregion
    }
}
