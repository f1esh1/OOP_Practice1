namespace OOP_Practice1.Core.GameSystem;

/// <summary>
/// Represents a support character capable of healing.
/// </summary>
public class Medic : Character
{
    public Medic(string name) : base(name, maxHealth: 85, armor: 5, attackPower: 12) { }

    /// <inheritdoc />
    public override void UseAbility(Character target)
    {
        Console.WriteLine($"[ABILITY] {Name} uses 'Field First Aid' on {target.Name}!");
        target.Heal(35);
    }
}