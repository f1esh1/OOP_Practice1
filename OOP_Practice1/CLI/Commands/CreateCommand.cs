using System;
using OOP_Practice1.Core.GameSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to create characters or items.
/// Usage:
///   create <warrior|medic> <name>
///   create item <name> [healthBonus] [armorBonus] [attackBonus]
/// </summary>
public class CreateCommand : ICommand
{
    public string Name => "create";

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: create <warrior|medic|item> <name>");
            return;
        }

        string type = args[0].ToLower();
        string name = args[1];

        switch (type)
        {
            case "warrior":
                var warrior = new Warrior(name);
                GameStore.Characters.Add(warrior); 
                Console.WriteLine($"[SUCCESS] Created Warrior '{warrior.Name}' with ID [{warrior.Id}].");
                break;

            case "medic":
                var medic = new Medic(name);
                GameStore.Characters.Add(medic); 
                Console.WriteLine($"[SUCCESS] Created Medic '{medic.Name}' with ID [{medic.Id}].");
                break;

            case "item":
                int hpBonus = args.Length > 2 && int.TryParse(args[2], out int h) ? h : 10;
                int armBonus = args.Length > 3 && int.TryParse(args[3], out int a) ? a : 5;
                int atkBonus = args.Length > 4 && int.TryParse(args[4], out int at) ? at : 15;

                var item = new Item(name, hpBonus, armBonus, atkBonus);
                GameStore.Items.Add(item); 
                Console.WriteLine($"[SUCCESS] Created Item '{item.Name}' with ID [{item.Id}].");
                break;

            default:
                Console.WriteLine($"Error: Unknown type '{type}'. Use 'warrior', 'medic', or 'item'.");
                break;
        }
    }
}