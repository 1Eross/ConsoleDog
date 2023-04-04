using System;


namespace DungeonSlayer.Units.Players.Perks
{
    class Perk
    {
        public EPerkValue value;
        public string info;
        public int level;

        public Perk(EPerkValue _value, string _info, int _level)
        {
            value = _value;
            info = _info;
            level = _level;
        }
    }
}
