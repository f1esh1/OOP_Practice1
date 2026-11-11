namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Represents a hyperlink element with display text and a destination URL.
/// </summary>
public class Link : TextElement
{
    public string Text { get; set; }
    public string Url { get; set; }

    public Link(string text, string url)
    {
        Text = text;
        Url = url;
    }

    public override string Render()
    {
        return $"[{Text}]({Url})";
    }
}