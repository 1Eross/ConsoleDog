using DungeonSlayer.Units.Players.Inventory.Helmets;


namespace DungeonSlayer.Units.Players.Inventory.Armores
{
    class Armor : Helmet
    {
        public Armor(string _name, int _blockingValue,int x ,int y, int _cost, int _level) :
                    base(_name, _blockingValue, x, y,  _cost, _level)
        {
            itemType = EItemType.ARMOR;
        }

        public override void Use()
        {

           
            Gameee.player.inventory.AddItem(Gameee.player.inventory.activeArmor);
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
