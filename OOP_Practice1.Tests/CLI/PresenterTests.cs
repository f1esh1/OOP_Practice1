using Moq;
using Xunit;
using OOP_Practice1.CLI.Presenter;
using OOP_Practice1.Infra.Display;

namespace OOP_Practice1.Tests.CLI;

public class PresenterTests
{
    [Fact]
    public void ShowError_AddsErrorPrefixAndWritesToDisplay()
    {
        // Arrange
        var mockDisplay = new Mock<IDisplay>();
        var presenter = new ConsolePresenter(mockDisplay.Object);
        string errorMessage = "Invalid command";

        // Act
        presenter.ShowError(errorMessage);

        // Assert
        // Verify that WriteLine was called exactly once with the correctly formatted string
        mockDisplay.Verify(d => d.WriteLine("[ERROR] Invalid command"), Times.Once);
    }

    [Fact]
    public void ShowHeader_FormatsHeaderCorrectly()
    {
        // Arrange
        var mockDisplay = new Mock<IDisplay>();
        var presenter = new ConsolePresenter(mockDisplay.Object);

        // Act
        presenter.ShowHeader("Main Menu");

        // Assert
        mockDisplay.Verify(d => d.WriteLine("\n=== Main Menu ==="), Times.Once);
    }
}