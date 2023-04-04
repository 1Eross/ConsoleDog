using DungeonSlayer.Units.Players.Inventory;
using DungeonSlayer.Units.Players.Perks;
using System;
using DungeonSlayer.Units;


namespace pppp
{
    class Playerrr : Personaaa
    
    {
        public PlayerInventory inventory;
        public PerksSystem perksSystem;
        public int currentGold = 5;
        public bool isDead = false, isMove = false;

        public Playerrr()
        {
            name = "Player";
            form = '@';
            color = ConsoleColor.Red;
            
            inventory = new PlayerInventory();
            perksSystem = new PerksSystem();
           
        }
    }
    }
