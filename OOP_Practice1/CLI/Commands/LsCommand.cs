using System;
using OOP_Practice1.Core.GameSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to list characters or items (ls <char|item> [--id <id/name>]).
/// </summary>
public class LsCommand : ICommand
{
    public string Name => "ls";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: ls <char|item> [--id <id/name>]");
            return;
        }

        string category = args[0].ToLower();
        string targetIdOrName = null;

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] == "--id" && i + 1 < args.Length)
            {
                targetIdOrName = args[i + 1];
                break;
            }
        }

        if (category == "char" || category == "character")
        {
            if (!string.IsNullOrEmpty(targetIdOrName))
            {
                var character = GameStore.FindCharacter(targetIdOrName);
                if (character == null)
                {
                    Console.WriteLine($"Character '{targetIdOrName}' not found.");
                    return;
                }
                Console.WriteLine($"[Full Info] ID: {character.Id} | Name: {character.Name} | HP: {character.Health} | Armor: {character.Armor} | Attack: {character.AttackPower}");
            }
            else
            {
                Console.WriteLine("--- Characters List ---");
                foreach (var c in GameStore.Characters)
                {
                    Console.WriteLine($"ID: {c.Id} | Name: {c.Name} | HP: {c.Health}");
                }
            }
        }
        else if (category == "item")
        {
            if (!string.IsNullOrEmpty(targetIdOrName))
            {
                var item = GameStore.FindItem(targetIdOrName);
                if (item == null)
                {
                    Console.WriteLine($"Item '{targetIdOrName}' not found.");
                    return;
                }
                Console.WriteLine($"[Full Info] ID: {item.Id} | Name: {item.Name} | HP Bonus: {item.HealthBonus} | Armor Bonus: {item.ArmorBonus} | Attack Bonus: {item.AttackBonus}");
            }
            else
            {
                Console.WriteLine("--- Items List ---");
                foreach (var item in GameStore.Items)
                {
                    Console.WriteLine($"ID: {item.Id} | Name: {item.Name}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Unknown category '{category}'. Use 'char' or 'item'.");
        }
    }
}