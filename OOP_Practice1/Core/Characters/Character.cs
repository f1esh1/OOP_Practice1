using System.Collections.Generic;

namespace OOP_Practice1.Core.GameSystem;

/// <summary>
/// Патерн Strategy: спеціалізується на параметризації поведінки 
/// об'єкта конкретним алгоритмом, 
/// дозволяючи легко змінювати чи додавати нові варіанти поведінки.
/// </summary>
public abstract class Character
{
    public string Id { get; } = Guid.NewGuid().ToString()[..6];
    private readonly List<Item> _equippedItems = new();

    /// <summary>
    /// Gets the character name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets current health points.
    /// </summary>
    public int Health { get; set; }

    /// <summary>
    /// Gets maximum health points.
    /// </summary>
    public int MaxHealth { get; protected set; }

    /// <summary>
    /// Gets armor value.
    /// </summary>
    public int Armor { get; protected set; }

    /// <summary>
    /// Gets attack power value.
    /// </summary>
    public int AttackPower { get; protected set; }

    /// <summary>
    /// Gets defensive mode status.
    /// </summary>
    public bool IsDefending { get; protected set; }

    protected Character(string name, int maxHealth, int armor, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Armor = armor;
        AttackPower = attackPower;
    }

    /// <summary>
    /// Equips an item and updates character statistics.
    /// </summary>
    public IReadOnlyList<Item> EquippedItems => _equippedItems;
    public void EquipItem(Item item)
    {
        _equippedItems.Add(item);
        MaxHealth += item.HealthBonus;
        Health += item.HealthBonus;
        Armor += item.ArmorBonus;
        AttackPower += item.AttackBonus;
        Console.WriteLine($"[EQUIP] {Name} equipped '{item.Name}' (+{item.AttackBonus} ATK, +{item.ArmorBonus} ARM, +{item.HealthBonus} HP).");
    }

    /// <summary>
    /// Performs a basic attack against a target character.
    /// </summary>
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"[ATTACK] {Name} attacks {target.Name} with {AttackPower} power!");
        target.TakeDamage(AttackPower);
    }

    /// <summary>
    /// Applies damage to the character, accounting for armor and stance.
    /// </summary>
    public void TakeDamage(int rawDamage)
    {
        int effectiveArmor = IsDefending ? Armor * 2 : Armor;
        int actualDamage = Math.Max(1, rawDamage - effectiveArmor);
        Health = Math.Max(0, Health - actualDamage);

        Console.WriteLine($"[DAMAGE] {Name} took {actualDamage} damage (Armor reduced {effectiveArmor}). HP: {Health}/{MaxHealth}.");
        IsDefending = false;
    }

    /// <summary>
    /// Restores health points.
    /// </summary>
    public void Heal(int amount)
    {
        Health = Math.Min(MaxHealth, Health + amount);
        Console.WriteLine($"[HEAL] {Name} healed for {amount} HP. Current HP: {Health}/{MaxHealth}.");
    }

    /// <summary>
    /// Activates defensive posture for the next hit.
    /// </summary>
    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"[DEFEND] {Name} enters defensive stance, doubling armor for the next incoming hit!");
    }

    /// <summary>
    /// Executes a unique character ability.
    /// </summary>
    public abstract void UseAbility(Character target);
}