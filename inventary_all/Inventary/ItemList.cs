using DungeonSlayer.Units.Players.Inventory.Armores;
using DungeonSlayer.Units.Players.Inventory.Bottles;
using DungeonSlayer.Units.Players.Inventory.Helmets;
using DungeonSlayer.Units.Players.Inventory.Weapons;
using System.Collections.Generic;
using System.Numerics;

namespace DungeonSlayer.Units.Players.Inventory
{
    static class ItemsList
    {
        static public HelthBottle helthBottle = new HelthBottle();
        static public ManaBottle manaBottle = new ManaBottle();

        static public Armor withoutArmor = new Armor("Without Armor", 0, 0, 0, 0, 0);
        static public Armor castoffs = new Armor("Сastoffs", 0, 0, 1, 0, 0);
        static public Armor ironArmor = new Armor("Iron Armor", 4, 0, 0, 20, 2);
        static public Armor robeStudent = new Armor("Robe Student", 0, 2, 0, 30, 3);
        static public Armor goblinArmor = new Armor("Goblin clothes", 2, 1, 0, 22, 3);
        static public Armor leatherArmor = new Armor("Leather Armor", 2, 1, 0, 23, 4);
        static public Armor stealArmor = new Armor("Steal Armor", 6, 0, 0, 44, 7);


        static public Helmet withoutHelmet = new Helmet("Without Helmet", 0, 0, 0, 33, 0);
        static public Helmet wellWornHood = new Helmet("Well-worn Hood", 0, 0, 0, 18, 0);
        static public Helmet ironHelmet = new Helmet("Iron Helmet", 2, 0, 0, 25, 2);

        static public Weapon stealSword = new Weapon("Steal Sword", 5, 90, 5, EWeaponType.SWORD,0, 4);
        static public Weapon stealSpear = new Weapon("Steal Spear", 4, 70, 15, EWeaponType.SPEAR, 44, 5);
        static public Weapon stealMace = new Weapon("Steal Mace", 5, 80, 9, EWeaponType.MACE, 22, 4);



        static public List<Item> items = new List<Item>
        {
            helthBottle,
            manaBottle,
            withoutArmor,
            castoffs,
            ironArmor,
            robeStudent,
            goblinArmor,
            leatherArmor,
            withoutHelmet,
            wellWornHood,
            ironHelmet,
            stealSword,
            stealSpear,
            stealMace,
            
        };

        static public Item GetItemByName(string name)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].name == name)
                {
                    return items[i];
                }
            }
            return items[0];


        }
    }
}
