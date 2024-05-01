namespace MyLife.Core.Models.Medium
{
    /// <summary>
    /// Represents a medium article model.
    /// </summary>
    /// <param name="Title">Title of the article</param>
    /// <param name="Abstract">Short abstract</param>
    /// <param name="PublishedAt">Date of publication</param>
    /// <param name="CoverImageUri">Url to the cover image</param>
    /// <param name="ArticleUri">Url to the article itself</param>
    public record MediumArticleModel(string Title, string Abstract, DateTime PublishedAt, Uri CoverImageUri, Uri ArticleUri);
}