using System;

namespace OOP_Practice1.CLI.Commands;

public class HelpCommand : ICommand
{
    public string Name => "help";

    public void Execute(string[] args)
    {
        Console.WriteLine("=== Available Commands ===");
        Console.WriteLine("  help                   - Show this list of commands");
        Console.WriteLine("  create <type> <name>   - Create character ('warrior' or 'medic')");
        Console.WriteLine("  exit                   - Quit application");
    }
}