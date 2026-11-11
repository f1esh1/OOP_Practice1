namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Патерн Builder : призначений для покрокового конструювання 
/// складних об'єктів, 
/// відокремлюючи процес конструювання від їхнього фінального представлення.
/// </summary>
public class DocumentBuilder
{
    private readonly TextDocument _document = new();

    public DocumentBuilder AddHeading(string text, int level)
    {
        _document.AddElement(new Heading(text, level));
        return this;
    }

    public DocumentBuilder AddParagraph(string text)
    {
        _document.AddElement(new Paragraph(text));
        return this;
    }

    public DocumentBuilder AddImage(string altText, string url)
    {
        _document.AddElement(new Image(altText, url));
        return this;
    }

    public DocumentBuilder AddLink(string text, string url)
    {
        _document.AddElement(new Link(text, url));
        return this;
    }

    public DocumentBuilder Move(int fromIndex, int toIndex)
    {
        _document.MoveElement(fromIndex, toIndex);
        return this;
    }

    public TextDocument Build()
    {
        return _document;
    }
}