using System;
using OOP_Practice1.Core.TextSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to add elements (heading, paragraph) to the shared text document.
/// Usage: addtext <heading|paragraph> <text> [level]
/// </summary>
public class AddTextCommand : ICommand
{
    public string Name => "addtext";

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: addtext <heading|paragraph> <text> [level]");
            return;
        }

        string type = args[0].ToLower();
        string text = args[1];

        switch (type)
        {
            case "heading":
                int level = args.Length > 2 && int.TryParse(args[2], out int l) ? l : 1;
                PrintCommand.Document.AddElement(new Heading(text, level));
                Console.WriteLine($"[SUCCESS] Added Heading (H{level}): '{text}'");
                break;

            case "paragraph":
                PrintCommand.Document.AddElement(new Paragraph(text));
                Console.WriteLine($"[SUCCESS] Added Paragraph: '{text}'");
                break;

            default:
                Console.WriteLine($"Error: Unknown type '{type}'. Use 'heading' or 'paragraph'.");
                break;
        }
    }
}