using System;
using OOP_Practice1.Core.GameSystem;
using OOP_Practice1.Infra.WebApi;

namespace OOP_Practice1.Core.GameSystem;

public static class CharacterFactory
{
    public static Warrior CreateFromGenshin(GenshinCharacterDto dto)
    {
        var random = new Random();
        int baseHealth = dto.Rarity >= 5 ? random.Next(150, 220) : random.Next(100, 150);

        var warrior = new Warrior(dto.Name);
        warrior.Health = baseHealth;

        return warrior;
    }

    public static Item CreateWeaponFromGenshin(GenshinWeaponDto dto)
    {
        int attackBonus = dto.BaseAttack > 0 ? dto.BaseAttack : dto.Rarity * 15;
        return new Item(dto.Name, healthBonus: 0, armorBonus: 0, attackBonus: attackBonus);
    }
}