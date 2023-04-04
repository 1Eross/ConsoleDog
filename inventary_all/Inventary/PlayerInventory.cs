using DungeonSlayer.Units.Players.Inventory.Armores;
using DungeonSlayer.Units.Players.Inventory.Helmets;
using DungeonSlayer.Units.Players.Inventory.Weapons;
using DungeonSlayer.Units.Players.Perks;
using System;
using System.Collections.Generic;


namespace DungeonSlayer.Units.Players.Inventory
{
    class PlayerInventory
    {
        public Helmet activeHelmet = ItemsList.wellWornHood;
        public Armor activeArmor = ItemsList.castoffs;
        public Weapon activeWeapon = ItemsList.workGloves;

        public List<Item> items;

        public PlayerInventory()
        {
            items = new List<Item>();
            items.Add(ItemsList.helthBottle);
            items.Add(ItemsList.helthBottle);
            items.Add(ItemsList.manaBottle);
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

/*        public void SetActiveHelmet(Helmet helmet)
        {
            Game.player.maxHelth -= (int)activeHelmet.increasingStats.X;
            Game.player.evasion -= (int)activeHelmet.increasingStats.Y;
            Game.player.specification.spellPower -= (int)activeHelmet.increasingStats.Z;

            Game.player.blocking -= activeHelmet.blockingValue;
            activeHelmet = helmet;
            Game.player.blocking += activeHelmet.blockingValue;

            Game.player.maxHelth += (int)activeHelmet.increasingStats.X;
            Game.player.evasion += (int)activeHelmet.increasingStats.Y;
            Game.player.specification.spellPower += (int)activeHelmet.increasingStats.Z;
        }

        public void SetActiveArmor(Armor armor)
        {
            Game.player.maxHelth -= (int)activeArmor.increasingStats.X;
            Game.player.evasion -= (int)activeArmor.increasingStats.Y;
            Game.player.specification.spellPower -= (int)activeArmor.increasingStats.Z;

            Game.player.blocking -= activeArmor.blockingValue;
            activeArmor = armor;
            Game.player.blocking += activeArmor.blockingValue;

            Game.player.maxHelth += (int)activeArmor.increasingStats.X;
            Game.player.evasion += (int)activeArmor.increasingStats.Y;
            Game.player.specification.spellPower += (int)activeArmor.increasingStats.Z;
        }
*/
        public void SetActiveWeapon(Weapon weapon, EPerkValue perk = EPerkValue.EMPTY_PERK)
        {
            Gameee.player.accuracy = weapon.accuracy;
            Gameee.player.criticalChance = weapon.criticalChance;
            if (perk != EPerkValue.DAGGER_PERK)
            {
                if ((activeWeapon.type == EWeaponType.DAGGER) && Gameee.player.perksSystem.CheckPerk(PerksList.daggerPerk))
                {
                    --Gameee.player.attack;
                }
            }
            if (perk != EPerkValue.MACE_PERK)
            {
                if ((activeWeapon.type == EWeaponType.MACE) && Gameee.player.perksSystem.CheckPerk(PerksList.macePerk))
                {
                    --Gameee.player.attack;
                }
            }
            if (perk != EPerkValue.AXE_PERK)
            {
                if ((activeWeapon.type == EWeaponType.AXE) && Gameee.player.perksSystem.CheckPerk(PerksList.axePerk))
                {
                    --Gameee.player.attack;
                }
            }
            if (perk != EPerkValue.SWORD_PERK)
            {
                if ((activeWeapon.type == EWeaponType.SWORD) && Gameee.player.perksSystem.CheckPerk(PerksList.swordPerk))
                {
                    --Gameee.player.attack;
                }
            }
            if (perk != EPerkValue.STAFF_PERK)
            {
                if ((activeWeapon.type == EWeaponType.STAFF) && Gameee.player.perksSystem.CheckPerk(PerksList.staffPerk))
                {
                    --Gameee.player.attack;
                }
            }
            if (perk != EPerkValue.SPEAR_PERK)
            {
                if ((activeWeapon.type == EWeaponType.SPEAR) && Gameee.player.perksSystem.CheckPerk(PerksList.spearPerk))
                {
                    --Gameee.player.attack;
                }
            }

            Gameee.player.attack -= activeWeapon.attack;
            activeWeapon = weapon;
            Gameee.player.attack += activeWeapon.attack;

            if ((activeWeapon.type == EWeaponType.DAGGER) && Gameee.player.perksSystem.CheckPerk(PerksList.daggerPerk))
            {
                ++Gameee.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.MACE) && Gameee.player.perksSystem.CheckPerk(PerksList.macePerk))
            {
                ++Gameee.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.AXE) && Gameee.player.perksSystem.CheckPerk(PerksList.axePerk))
            {
                ++Gameee.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.SWORD) && Gameee.player.perksSystem.CheckPerk(PerksList.swordPerk))
            {
                ++Gameee.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.STAFF) && Gameee.player.perksSystem.CheckPerk(PerksList.staffPerk))
            {
                ++Gameee.player.attack;
            }
            if ((activeWeapon.type == EWeaponType.SPEAR) && Gameee.player.perksSystem.CheckPerk(PerksList.spearPerk))
            {
                ++Gameee.player.attack;
            }
        }


    }
}