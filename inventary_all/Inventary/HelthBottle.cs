using DungeonSlayer.Units.Players.Perks;

namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class HelthBottle : Item
    {
        public HelthBottle()
        {
            name = "Helth Bottle";
            itemType = EItemType.ITEM;
        }

        public override void Use()
        {
            Gameee.player.helth += (20 + (Gameee.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0));
            if (Gameee.player.helth > Gameee.player.maxHelth)
            {
                Gameee.player.helth = Gameee.player.maxHelth;
            }
        }

        public override string GetInfo()
        {
            return "Heal " + (20 + (Gameee.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0)) + " health" + ", Cost: " + cost;
        }
    }
}
