using System;
using OOP_Practice1.Core.GameSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to attach an item to a character (add --char_id <id/name> --id <id/name>).
/// </summary>
public class AddCommand : ICommand
{
    public string Name => "add";

    public void Execute(string[] args)
    {
        string charTarget = null;
        string itemTarget = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--char_id" && i + 1 < args.Length)
            {
                charTarget = args[i + 1];
            }
            else if (args[i] == "--id" && i + 1 < args.Length)
            {
                itemTarget = args[i + 1];
            }
        }

        if (string.IsNullOrEmpty(charTarget) || string.IsNullOrEmpty(itemTarget))
        {
            Console.WriteLine("Usage: add --char_id <char_id/name> --id <item_id/name>");
            return;
        }

        var character = GameStore.FindCharacter(charTarget);
        if (character == null)
        {
            Console.WriteLine($"Character '{charTarget}' not found.");
            return;
        }

        var item = GameStore.FindItem(itemTarget);
        if (item == null)
        {
            Console.WriteLine($"Item '{itemTarget}' not found.");
            return;
        }

        character.EquipItem(item);
        Console.WriteLine($"Successfully equipped '{item.Name}' onto '{character.Name}'.");
    }
}