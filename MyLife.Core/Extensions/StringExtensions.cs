using System.Text.RegularExpressions;

namespace MyLife.Core.Extensions
{
    /// <summary>
    /// Summary class of [String] extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        #region Public extensions 

        /// <summary>
        /// Truncates itself to a maximum length.
        /// It will cut-off at the last word that fits in
        /// the range.
        /// </summary>
        /// <param name="input">This string that shall be truncated</param>
        /// <param name="maxLength">Maximum length afterwards it should be truncated. Default value: 200</param>
        /// <returns>Truncated value</returns>
        public static string Truncate(this string input, int maxLength = 200)
        {
            // Return input if it is longer than maxLength.
            if (input.Length <= maxLength)
            {
                return input;
            }

            // Shorten input to maxlength
            var shortedInput = input[..(maxLength - 4)];

            // Get index of last space
            var indexLastSpacer = shortedInput.LastIndexOf(" ");

            // If there is a last space in input
            if (indexLastSpacer > 0)
            {
                // Truncate it at the space and append '...'
                return $"{shortedInput[..indexLastSpacer]} ...";
            }

            // Else return shortened string
            return shortedInput;
        }

        /// <summary>
        /// Extracts the first url value of an image tag in this string.
        /// </summary>
        /// <param name="input">Html content string.</param>
        /// <returns>Found first url value, elsewise null.</returns>
        public static string? ExtractFirstImageUrlFromHtml(this string input)
        {
            var match = ImageHtmlTagUrlRegex().Match(input);

            return match.Success
                ? match.Groups[1].Value
                : null;
        }

        /// <summary>
        /// Removes all html tags of this string.
        /// </summary>
        /// <param name="input">Html content string.</param>
        /// <returns>THis string without html tags.</returns>
        public static string RemoveHtmlTags(this string input)
        {
            return HtmlTagRegex().Replace(input, string.Empty);
        }

        #endregion

        #region Private regex

        /// <summary>
        /// Finds url of an image html tag.
        /// </summary>
        [GeneratedRegex("<img[^>]*src=\"([^\"]+)\"[^>]*>")]
        private static partial Regex ImageHtmlTagUrlRegex();

        /// <summary>
        /// Finds html tags.
        /// </summary>
        [GeneratedRegex("<.*?>")]
        private static partial Regex HtmlTagRegex();

        #endregion
    }
}
