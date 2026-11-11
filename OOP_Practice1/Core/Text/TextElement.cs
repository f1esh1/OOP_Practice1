using System;

namespace OOP_Practice1.Core.TextSystem;

public abstract class TextElement
{
    public string Id { get; set; } = Guid.NewGuid().ToString()[..6]; // Short unique ID
    public TextElement Parent { get; set; } // Reference to parent for navigation

    public abstract string Render();
}