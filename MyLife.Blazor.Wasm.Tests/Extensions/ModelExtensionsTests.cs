using MyLife.Blazor.Wasm.Extensions;
using MyLife.Core.Models.CurriculumVitae;
using MyLife.Core.Models.Shared;
using Xunit;

namespace MyLife.Blazor.Wasm.Tests.Extensions
{
    public class ModelExtensionsTests
    {
        [Fact]
        public void GetOnlyYearJoined_ValidDate_ReturnsYear()
        {
            var employment = new Employment { Joined = "01-2023" };
            Assert.Equal("2023", employment.GetOnlyYearJoined());
        }

        [Fact]
        public void GetOnlyYearJoined_InvalidDate_ThrowsException()
        {
            var employment = new Employment { Joined = "invalid" };
            Assert.Throws<IndexOutOfRangeException>(() => employment.GetOnlyYearJoined());
        }

        [Fact]
        public void GetIconLinkElement_TwitterAccount_ReturnsCorrectHtml()
        {
            var account = new Core.Models.SocialMedia.Account
            {
                Platform = Platform.Twitter,
                Username = "test",
                Url = new Uri("https://twitter.com/test")
            };

            var html = account.GetIconLinkElement();
            Assert.Contains("fa-twitter", html);
            Assert.Contains("@test", html);
        }

        [Fact]
        public void GetIconLinkElement_NullUrl_ThrowsException()
        {
            var account = new Core.Models.SocialMedia.Account
            {
                Platform = Platform.Twitter,
                Username = "test",
                Url = null
            };

            Assert.Throws<ArgumentNullException>(() => account.GetIconLinkElement());
        }
    }
}
