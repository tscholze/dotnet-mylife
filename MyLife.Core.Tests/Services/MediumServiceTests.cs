using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using MyLife.Core.Models.Medium;
using MyLife.Core.Services;
using Xunit;

namespace MyLife.Core.Tests.Services
{
    public class MediumServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly MediumService _mediumService;

        public MediumServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _mediumService = new MediumService(_httpClient);
        }

        [Fact]
        public async Task GetFeedsByUsernames_ReturnsCachedFeeds_WhenAlreadyFetched()
        {
            // Arrange
            var usernames = new[] { "testuser" };
            var expectedFeed = new MediumFeedModel("Test Feed", DateTime.Now, new List<MediumArticleModel>());
            await _mediumService.GetFeedsByUsernames(usernames); // Populate cache

            // Act
            var result = await _mediumService.GetFeedsByUsernames(usernames);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedFeed.Title, result["testuser"].Title);
        }

        [Fact]
        public async Task LoadPublicationsAsync_ReturnsPublications_WhenFeedIsValid()
        {
            // Arrange
            var handle = "testuser";
            var feedContent = "<rss><channel><title>Test Feed</title></channel></rss>";
            SetupHttpResponse(HttpStatusCode.OK, feedContent);

            // Act
            var result = await _mediumService.LoadPublicationsAsync(handle);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result); // No articles in the mocked feed
        }

        [Fact]
        public async Task LoadPublicationsAsync_ReturnsEmptyList_WhenFeedIsInvalid()
        {
            // Arrange
            var handle = "invaliduser";
            SetupHttpResponse(HttpStatusCode.NotFound, string.Empty);

            // Act
            var result = await _mediumService.LoadPublicationsAsync(handle);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        private void SetupHttpResponse(HttpStatusCode statusCode, string content)
        {
            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content)
                });
        }
    }
}
