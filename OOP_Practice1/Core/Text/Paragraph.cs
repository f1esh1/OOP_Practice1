namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Represents a standard paragraph of text.
/// </summary>
public class Paragraph : TextElement
{
    public string Text { get; set; }

    public Paragraph(string text)
    {
        Text = text;
    }

    public override string Render()
    {
        return Text;
    }
}