namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Represents an embedded image element with alt text and a URL.
/// </summary>
public class Image : TextElement
{
    public string AltText { get; set; }
    public string Url { get; set; }

    public Image(string altText, string url)
    {
        AltText = altText;
        Url = url;
    }

    public override string Render()
    {
        return $"![{AltText}]({Url})";
    }
}