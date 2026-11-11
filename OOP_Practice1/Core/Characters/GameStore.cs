using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Practice1.Core.GameSystem;

/// <summary>
/// Central store to retain characters and items created during CLI session.
/// </summary>
public static class GameStore
{
    public static List<Character> Characters { get; } = new();
    public static List<Item> Items { get; } = new();

    public static Character FindCharacter(string idOrName)
    {
        return Characters.FirstOrDefault(c =>
            c.Id.Equals(idOrName, StringComparison.OrdinalIgnoreCase) ||
            c.Name.Equals(idOrName, StringComparison.OrdinalIgnoreCase));
    }

    public static Item FindItem(string idOrName)
    {
        return Items.FirstOrDefault(i =>
            i.Id.Equals(idOrName, StringComparison.OrdinalIgnoreCase) ||
            i.Name.Equals(idOrName, StringComparison.OrdinalIgnoreCase));
    }
}