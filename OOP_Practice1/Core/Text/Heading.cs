namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Represents a heading text element with a specific level (e.g., H1, H2).
/// </summary>
public class Heading : TextElement
{
    public string Text { get; set; }
    public int Level { get; set; }

    public Heading(string text, int level)
    {
        Text = text;
        Level = level;
    }

    public override string Render()
    {
        string prefix = new string('#', Level);
        return $"{prefix} {Text}";
    }
}