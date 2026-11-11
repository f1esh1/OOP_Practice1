using System.Collections.Generic;
using System.Text;

namespace OOP_Practice1.Core.TextSystem
{
    public class TextDocument
    {
        private readonly List<TextElement> _elements = new();

        public void AddElement(TextElement element) => _elements.Add(element);

        public void MoveElement(int oldIndex, int newIndex)
        {
            if (oldIndex >= 0 && oldIndex < _elements.Count && newIndex >= 0 && newIndex <= _elements.Count)
            {
                var item = _elements[oldIndex];
                _elements.RemoveAt(oldIndex);
                if (newIndex > oldIndex) newIndex--;
                _elements.Insert(newIndex, item);
            }
        }

        public string GetTableOfContents()
        {
            var toc = new StringBuilder();
            foreach (var element in _elements)
            {
                if (element is Heading heading)
                {
                    string indent = new string(' ', (heading.Level - 1) * 2);
                    toc.AppendLine($"{indent}- {heading.Text}");
                }
            }
            return toc.ToString();
        }

        public string RenderDocument()
        {
            var content = new StringBuilder();
            foreach (var element in _elements)
            {
                content.AppendLine(element.Render());
                content.AppendLine();
            }
            return content.ToString().TrimEnd();
        }
    }
}