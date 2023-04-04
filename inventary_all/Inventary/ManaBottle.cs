using DungeonSlayer.Units.Players.Perks;

namespace DungeonSlayer.Units.Players.Inventory.Bottles
{
    class ManaBottle : Item
    {
        public ManaBottle()
        {
            name = "Mana Bottle";
            itemType = EItemType.ITEM;
        }

        public override void Use()
        {
            Gameee.player.mana += (20 + (Gameee.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0));
            if (Gameee.player.mana > Gameee.player.maxMana)
            {
                Gameee.player.mana = Gameee.player.maxMana;
            }
        }

        public override string GetInfo()
        {
            return "Restores " + (20 + (Gameee.player.perksSystem.CheckPerk(PerksList.healPerk) ? 5 : 0)) + " mana" + ", Cost: " + cost;
        }
    }
}
