using MyLife.Core.Models;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Models.Shared;
using Xunit;

namespace MyLife.Core.Tests.Generator;

public class ExporterTests
{
    [Fact]
    public void ExportLife_WithValidLife_ReturnsValidJson()
    {
        // Arrange
        var life = new Life
        {
            ContentCreation = new Container
            {
                Accounts = new List<Account>()
            }
        };

        // Act
        var result = Exporter.ExportLife(life);

        // Assert
        Assert.NotNull(result);
        Assert.Contains("ContentCreation", result);
    }

    [Fact]
    public void ExportLife_WithNullLife_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Exporter.ExportLife(null));
    }

    [Fact]
    public async Task ExportPublicationsAsync_WithNullContainer_ThrowsArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => 
            Exporter.ExportPublicationsAsync(null));
    }

    [Fact]
    public async Task ExportPublicationsAsync_WithEmptyContainer_ReturnsEmptyJsonArray()
    {
        // Arrange
        var container = new Container
        {
            Accounts = new List<Account>()
        };

        // Act
        var result = await Exporter.ExportPublicationsAsync(container, false);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("[]", result);
    }
}
