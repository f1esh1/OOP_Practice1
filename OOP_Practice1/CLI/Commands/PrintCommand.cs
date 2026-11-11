using System;
using OOP_Practice1.Core.TextSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to display the rendered content of the text document.
/// </summary>
public class PrintCommand : ICommand
{
    private static readonly Text SharedDocument = new();

    public static Text Document => SharedDocument;

    public string Name => "print";

    public void Execute(string[] args)
    {
        Console.WriteLine("=== DOCUMENT CONTENT ===");
        string content = SharedDocument.ToString();

        if (string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("[Document is empty]");
        }
        else
        {
            Console.WriteLine(content);
        }
    }
}