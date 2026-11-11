using System;
using OOP_Practice1.Core.TextSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to print the table of contents / structure path of the document.
/// </summary>
public class PwdCommand : ICommand
{
    public string Name => "pwd";

    public void Execute(string[] args)
    {
        Console.WriteLine("=== CURRENT DOCUMENT STRUCTURE ===");
        string toc = PrintCommand.Document.GetTableOfContents();

        if (string.IsNullOrWhiteSpace(toc))
        {
            Console.WriteLine("/");
        }
        else
        {
            Console.WriteLine(toc);
        }
    }
}