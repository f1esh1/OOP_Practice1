using OOP_Practice1.Core.GameSystem;
using Xunit;

namespace OOP_Practice1.Tests.Core;

public class WarriorTests
{
    [Fact]
    public void Warrior_Creation_SetsCorrectNameAndHealth()
    {
        // Arrange & Act
        var warrior = new Warrior("Arthur");

        // Assert
        Assert.Equal("Arthur", warrior.Name);
        Assert.True(warrior.Health > 0);
    }
}