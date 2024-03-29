﻿using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory.Weapons
{
    enum EWeaponType
    {
        SWORD,
        DAGGER,
        STAFF,
        KATANA,
        MACE,
        SPEAR,
        HAND,
        AXE
    }

    class Weapon : Item
    {
        public int attack;
        public int accuracy;
        public int criticalChance;
        public EWeaponType type;

        public Weapon(string _name, int _attack, int _accuracy, int _criticalChance, EWeaponType _type, int _cost, int _level)
        {
            name = _name;
            attack = _attack;
            type = _type;
            accuracy = _accuracy;
            criticalChance = _criticalChance;
            cost = _cost;
            level = _level;
            itemType = EItemType.WEAPON;
        }

        public override void Use()
        {
            Gameee.player.inventory.AddItem(Gameee.player.inventory.activeWeapon);
            Gameee.player.inventory.SetActiveWeapon(this);
        }

        public override string GetInfo()
        {
            return " Type: " + type +
                   ", Attack: " + attack + ", Cost: " + cost +
                   ", Accuracy: " + accuracy + ", Critical Chance: " + criticalChance;
        }
    }
}
