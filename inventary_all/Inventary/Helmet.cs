

namespace DungeonSlayer.Units.Players.Inventory.Helmets
{
    class Helmet : Item
    {
        public int blockingValue;
        public int increasingStats;

        public Helmet(string _name, int _blockingValue,int x, int y, int _cost, int _level)
        {
            name = _name;
            blockingValue = _blockingValue;
            cost = _cost;
            level = _level;
            itemType = EItemType.HELMET;
        }

        public override void Use()
        {
            Gameee.player.inventory.AddItem(Gameee.player.inventory.activeHelmet);
/*            Gameee.player.inventory.SetActiveHelmet(this);*/
            
        }

/*        public override string GetInfo()
        {
            return " Defense: " + blockingValue + ", Cost: " + cost +
                   ", Increasing Helth - " + increasingStats.X +
                   ", Increasing Evasion - " + increasingStats.Y +
                   ", Increasing Spell Power - " + increasingStats.Z;
        }*/
    }
}
