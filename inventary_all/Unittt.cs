using System;

namespace DungeonSlayer.Units
{
    class Unit
    {
        protected char form;
        protected ConsoleColor color = ConsoleColor.White;


        public char GetForm()
        {
            return form;
        }
    }
}

