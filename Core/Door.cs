/*using ConsoleDog.Interface;
using ConsoleDog.Map;
using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Core
{
    public class Door : IDrowable
    {
        public Door() 
        {
            Symbol = '+';
            Color = Colors.Door;
            BackgroundColor = Colors.DoorBackground; // ?????
        }
        public bool IsOpen { get; set; }

        public RLColor Color { get; set; } 
        public RLColor BackgroundColor { get; set;}
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        

        public void Draw(RLConsole console, ConsoleDogMap map) // IMAP map github
        {
            if (!map.GetCell(X, Y)._IsExplored)
            {
                return;
            }

            Symbol = IsOpen ? '-' : '+';
            if (map.IsInFov(X, Y)) //// Proverka
            {
                Color = Colors.DoorFov;
                BackgroundColor = Colors.DoorBackgroundFov;
            }
            else
            {
                Color = Colors.Door;
                BackgroundColor = Colors.DoorBackground;
            }
            console.Set(X, Y, Color, BackgroundColor, Symbol);
        }
        
    }
}
*/