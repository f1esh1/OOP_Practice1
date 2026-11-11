using System.Collections.Generic;
using System.Text;

namespace OOP_Practice1.Core.TextSystem;

/// <summary>
/// Container class that holds and manages a sequence of TextElement objects.
/// </summary>
public class Text
{
    private readonly List<TextElement> _elements = new();

    public void AddElement(TextElement element)
    {
        _elements.Add(element);
    }

    public void MoveElement(int fromIndex, int toIndex)
    {
        if (fromIndex >= 0 && fromIndex < _elements.Count && toIndex >= 0 && toIndex < _elements.Count)
        {
            var item = _elements[fromIndex];
            _elements.RemoveAt(fromIndex);
            _elements.Insert(toIndex, item);
        }
    }

    public string GetTableOfContents()
    {
        var sb = new StringBuilder();
        int index = 1;

        foreach (var element in _elements)
        {
            if (element is Heading heading)
            {
                sb.AppendLine($"{index++}. {heading.Text}");
            }
        }

        return sb.ToString();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var element in _elements)
        {
            sb.AppendLine(element.Render());
            sb.AppendLine();
        }

        return sb.ToString().TrimEnd();
    }
}