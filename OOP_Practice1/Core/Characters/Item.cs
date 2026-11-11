namespace OOP_Practice1.Core.GameSystem;

/// <summary>
/// Represents an equipment item that modifies character stats.
/// </summary>
public class Item
{
    public string Id { get; } = Guid.NewGuid().ToString()[..6];
    /// <summary>
    /// Gets the item name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets health bonus provided by the item.
    /// </summary>
    public int HealthBonus { get; }

    /// <summary>
    /// Gets armor bonus provided by the item.
    /// </summary>
    public int ArmorBonus { get; }

    /// <summary>
    /// Gets attack power bonus provided by the item.
    /// </summary>
    public int AttackBonus { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class.
    /// </summary>
    public Item(string name, int healthBonus, int armorBonus, int attackBonus)
    {
        Name = name;
        HealthBonus = healthBonus;
        ArmorBonus = armorBonus;
        AttackBonus = attackBonus;
    }
}