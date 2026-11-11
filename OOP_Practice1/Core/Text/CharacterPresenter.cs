using OOP_Practice1.Core.GameSystem;
using OOP_Practice1.Core.TextSystem;

namespace OOP_Practice1.Core.Text;

public static class CharacterPresenter
{
    // Generates a structured Document Representation for a character
    public static TextDocument BuildCharacterReport(Warrior warrior, string vision, string description)
    {
        var builder = new DocumentBuilder();
        builder.AddHeading($"CHARACTER CARD: {warrior.Name.ToUpper()}", 1);
        builder.AddParagraph($"Vision/Element: {vision}");
        builder.AddParagraph($"Description: {description}");
        builder.AddParagraph($"Base Health: {warrior.Health}");
        builder.AddParagraph($"Equipped Items Count: {warrior.EquippedItems.Count}");

        return builder.Build();
    }
}