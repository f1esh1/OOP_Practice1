using System;
using OOP_Practice1.Core.GameSystem;

namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Command to execute combat actions (act <attack|heal|ability> <actor> <target>).
/// </summary>
public class ActCommand : ICommand
{
    public string Name => "act";

    public void Execute(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: act <attack|heal|ability> <actor_id/name> <target_id/name>");
            return;
        }

        string action = args[0].ToLower();
        string actorStr = args[1];
        string targetStr = args[2];

        var actor = GameStore.FindCharacter(actorStr);
        var target = GameStore.FindCharacter(targetStr);

        if (actor == null)
        {
            Console.WriteLine($"Actor character '{actorStr}' not found.");
            return;
        }

        if (target == null)
        {
            Console.WriteLine($"Target character '{targetStr}' not found.");
            return;
        }

        switch (action)
        {
            case "attack":
                actor.Attack(target);
                break;
            case "heal":
                actor.Heal(25);
                break;
            case "ability":
                actor.UseAbility(target);
                break;
            default:
                Console.WriteLine($"Unknown action '{action}'. Use 'attack', 'heal', or 'ability'.");
                break;
        }
    }
}