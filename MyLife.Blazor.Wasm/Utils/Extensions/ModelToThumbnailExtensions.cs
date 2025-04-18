﻿using MyLife.Blazor.Wasm.Components.Shared;

namespace MyLife.Blazor.Wasm.Utils.Extensions
{
    /// <summary>
    /// Summary of model to thumbnail extension.
    /// </summary>
    public static class ModelToThumbnailExtensions
    {
        /// <summary>
        /// Converts an open source project to a thumbnail.
        /// </summary>
        /// <param name="project">Project to convert</param>
        /// <returns>Thumbnail item</returns>
        public static ThumbnailGrid.GridItem ToThumbnail(this Core.Models.OpenSource.Project project)
        {
            return new ThumbnailGrid.GridItem
            {
                Name = project.Name,
                Description = project.Description,
                ImageUrl = project.ImageUrl.ToString(),
                TargetUrl = project.GithubUrl.ToString()
            };
        }

        /// <summary>
        /// Converts an content creation publication to a thumbnail.
        /// </summary>
        /// <param name="publication">Publication to convert</param>
        /// <returns>Thumbnail item</returns>
        public static ThumbnailGrid.GridItem ToThumbnail(this Core.Models.ContentCreation.Publication publication)
        {
            return new ThumbnailGrid.GridItem
            {
                Name = publication.Title,
                Description = publication.Description,
                ImageUrl = publication.ImageUrl.ToString(),
                TargetUrl = publication.Url.ToString()
            };
        }


        /// <summary>
        /// Converts a Medium article to a thumbnail.
        /// </summary>
        /// <param name="article">Article to convert</param>
        /// <returns>Thumbnail item</returns>
        public static ThumbnailGrid.GridItem ToThumbnail(this Core.Models.Medium.MediumArticleModel article)
        {
            return new ThumbnailGrid.GridItem
            {
                Name = article.Title,
                Description = article.Abstract,
                ImageUrl = article.CoverImageUri.ToString(),
                TargetUrl = article.ArticleUri.ToString()
            };
        }

        /// <summary>
        /// Converts a list of Medium articles to a thumbnails.
        /// </summary>
        /// <param name="articles">Articles to convert</param>
        /// <returns>Thumbnail items</returns>
        public static IEnumerable<ThumbnailGrid.GridItem> ToThumbnails(this IEnumerable<Core.Models.Medium.MediumArticleModel> articles)
        {
            return articles.Select(article => article.ToThumbnail());    
        }

        /// <summary>
        /// Converts a list of open source projects to thumbnails.
        /// </summary>
        /// <param name="projects">List of projects to convert.</param>
        /// <returns>Collection of thumbnail items.</returns>
        public static IEnumerable<ThumbnailGrid.GridItem> ToThumbnails(this IEnumerable<Core.Models.OpenSource.Project> projects)
        {
            return projects.Select(project => project.ToThumbnail());
        }

        /// <summary>
        /// Converts a list of open source projects to a thumbnails.
        /// </summary>
        /// <param name="publications">List of publications</param>
        /// <returns>Thumbnail items</returns>
        public static IEnumerable<ThumbnailGrid.GridItem> ToThumbnails(this IEnumerable<Core.Models.ContentCreation.Publication> publications)
        {
            return publications.Select(publication => publication.ToThumbnail());
        }
    }
}
