using Moq;
using OOP_Practice1.Core.GameSystem;
using OOP_Practice1.Infra.WebApi;
using System.Threading.Tasks;
using Xunit;

namespace OOP_Practice1.Tests.Infra;

public class WebApiTests
{
    [Fact]
    public async Task GetCharacterAsync_ReturnsCorrectDto_WhenMocked()
    {
        // Arrange
        var mockService = new Mock<IGenshinApiService>();
        mockService.Setup(s => s.GetCharacterAsync("amber"))
                   .ReturnsAsync(new GenshinCharacterDto
                   {
                       Name = "Amber",
                       Rarity = 4,
                       Vision = "Pyro",
                       Description = "Outrider of the Knights of Favonius."
                   });

        // Act
        var result = await mockService.Object.GetCharacterAsync("amber");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Amber", result.Name);
        Assert.Equal(4, result.Rarity);
    }

    [Fact]
    public void CharacterFactory_CreatesWarrior_WithCorrectRarityStats()
    {
        // Arrange
        var dto = new GenshinCharacterDto
        {
            Name = "Diluc",
            Rarity = 5,
            Vision = "Pyro"
        };

        // Act
        Warrior warrior = CharacterFactory.CreateFromGenshin(dto);

        // Assert
        Assert.Equal("Diluc", warrior.Name);
        Assert.InRange(warrior.Health, 150, 220); // 5-star character health range
    }
}