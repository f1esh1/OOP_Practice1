using OOP_Practice1.Core.GameSystem;
using OOP_Practice1.Infra.Data;
using System.IO;
using Xunit;

namespace OOP_Practice1.Tests.Infra;

public class DataSerializerTests
{
    [Fact]
    public void SaveAndLoadFromJson_RestoresObjectCorrectly()
    {
        // Arrange
        string filePath = "test_data.json";
        var originalWarrior = new Warrior("Lancelot");

        // Act
        DataSerializer.SaveToJson(filePath, originalWarrior);
        var loadedWarrior = DataSerializer.LoadFromJson<Warrior>(filePath);

        // Assert
        Assert.NotNull(loadedWarrior);
        Assert.Equal(originalWarrior.Name, loadedWarrior.Name);

        // Cleanup test file
        if (File.Exists(filePath)) File.Delete(filePath);
    }
}