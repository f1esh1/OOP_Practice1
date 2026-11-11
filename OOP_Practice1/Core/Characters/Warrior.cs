namespace OOP_Practice1.Core.GameSystem;

/// <summary>
/// Represents a heavy warrior focused on strong attacks.
/// </summary>
public class Warrior : Character
{
    public Warrior(string name) : base(name, maxHealth: 120, armor: 10, attackPower: 25) { }

    /// <inheritdoc />
    public override void UseAbility(Character target)
    {
        Console.WriteLine($"[ABILITY] {Name} uses 'Heavy Shield Strike' on {target.Name}!");
        int bonusDamage = AttackPower + 15;
        target.TakeDamage(bonusDamage);
    }
}