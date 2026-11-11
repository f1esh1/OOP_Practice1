using System;

namespace OOP_Practice1.Core.GameSystem;

public class Game
{
    private Warrior _warrior;
    private Medic _medic;

    public Game()
    {
        _warrior = new Warrior("Assault Specialist");
        _medic = new Medic("Field Medic");
    }

    public void StartSimulation()
    {
        Console.WriteLine($"Created: {_warrior.Name} (HP: {_warrior.Health}, ARM: {_warrior.Armor}, ATK: {_warrior.AttackPower})");
        Console.WriteLine($"Created: {_medic.Name} (HP: {_medic.Health}, ARM: {_medic.Armor}, ATK: {_medic.AttackPower})\n");

        var tacticalVest = new Item("Tactical Body Armor", healthBonus: 20, armorBonus: 8, attackBonus: 0);
        _warrior.EquipItem(tacticalVest);
        Console.WriteLine();

        _warrior.Attack(_medic);
        Console.WriteLine();

        _medic.Defend();
        _warrior.Attack(_medic);
        Console.WriteLine();

        _medic.UseAbility(_medic);
        Console.WriteLine();

        _warrior.UseAbility(_medic);
        Console.WriteLine();

        Console.WriteLine("Simulation completed successfully!");
    }
}