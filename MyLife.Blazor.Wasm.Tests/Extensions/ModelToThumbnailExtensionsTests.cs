using MyLife.Blazor.Wasm.Utils.Extensions;
using MyLife.Core.Models.OpenSource;
using Xunit;

namespace MyLife.Blazor.Wasm.Tests.Extensions
{
    public class ModelToThumbnailExtensionsTests
    {
        [Fact]
        public void ToThumbnail_Project_CreatesValidThumbnail()
        {
            // Arrange
            var project = new Project
            {
                Name = "Test Project",
                Descripton = "Test Description",
                ImageUrl = new Uri("https://example.com/image.jpg"),
                GithubUrl = new Uri("https://github.com/test")
            };

            // Act
            var thumbnail = project.ToThumbnail();

            // Assert
            Assert.Equal(project.Name, thumbnail.Name);
            Assert.Equal(project.Descripton, thumbnail.Description);
            Assert.Equal(project.ImageUrl.ToString(), thumbnail.ImageUrl);
            Assert.Equal(project.GithubUrl.ToString(), thumbnail.TargetUrl);
        }

        [Fact]
        public void ToThumbnails_EmptyList_ReturnsEmptyEnumerable()
        {
            // Arrange
            var articles = Enumerable.Empty<Core.Models.Medium.MediumArticleModel>();

            // Act
            var thumbnails = articles.ToThumbnails();

            // Assert
            Assert.Empty(thumbnails);
        }

        [Fact]
        public void ToThumbnail_Publication_CreatesValidThumbnail()
        {
            // Arrange
            var publication = new Core.Models.ContentCreation.Publication
            {
                Title = "Test Title",
                Description = "Test Description",
                ImageUrl = new Uri("https://example.com/image.jpg"),
                Url = new Uri("https://example.com/article")
            };

            // Act
            var thumbnail = publication.ToThumbnail();

            // Assert
            Assert.Equal(publication.Title, thumbnail.Name);
            Assert.Equal(publication.Description, thumbnail.Description);
            Assert.Equal(publication.ImageUrl.ToString(), thumbnail.ImageUrl);
            Assert.Equal(publication.Url.ToString(), thumbnail.TargetUrl);
        }
    }
}
