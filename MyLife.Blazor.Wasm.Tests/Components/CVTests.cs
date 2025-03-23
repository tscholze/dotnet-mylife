using Bunit;
using MyLife.Blazor.Wasm.Components.CV;
using MyLife.Core.Models.CurriculumVitae;
using Xunit;

namespace MyLife.Blazor.Wasm.Tests.Components
{
    public class CVTests
    {
        [Fact]
        public void CurriculumVitae_ValidData_RendersCorrectly()
        {
            // Arrange
            using var ctx = new TestContext();
            var data = new Container
            {
                RecentEmployments = new[] { new Employment { Role = "Dev", Company = "Test Co", Joined = "01-2023" } },
                Educations = Array.Empty<Education>(),
                Skillset = new Skillset 
                { 
                    DevelopmentEnvironments = new[] { "VS Code" },
                    ProgrammingLanguages = new[] { "C#" },
                    DesignEnvironments = new[] { "Figma" },
                    DesignGuidelines = new[] { "Material" },
                    SoftSkills = new[] { "Team work" }
                },
                Activities = new[] { "Coding" },
                OtherInterests = new[] { "Reading" }
            };

            // Act
            var cut = ctx.RenderComponent<CurriculumVitae>(parameters => parameters
                .Add(p => p.Data, data));

            // Assert
            cut.FindAll("h3").Count.Should().Be(4);
            cut.Find("h2").TextContent.Should().Contain("Vitae");
        }
    }
}
