using Microsoft.Extensions.DependencyInjection;
using MyLife.Core.Services;
using Xunit;

namespace MyLife.Blazor.Wasm.Tests.Extensions
{
    public class IntegrationTests
    {
        [Fact]
        public async Task LifeService_GetLife_ReturnsValidData()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost") });
            services.AddSingleton<LifeService>();
            var provider = services.BuildServiceProvider();
            var service = provider.GetRequiredService<LifeService>();

            // Act
            var life = await service.GetLife();

            // Assert 
            Assert.NotNull(life);
            Assert.NotNull(life.Persona);
            Assert.NotEmpty(life.Persona.IntroductionParagraphs);
        }
    }
}
