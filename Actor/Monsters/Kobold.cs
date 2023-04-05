using RLNET;
using RogueSharp.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Actor.Monsters
{
    internal class Kobold : Monster
    {
        public static Kobold Create(int level)
        {
            int health = Program.Rand.Next(30, 50) + (level - 1) * 10;
            return new Kobold
            {
                Name = "Kobold",
                Symbol = 'k',
                Health = health,
                Attack = Program.Rand.Next(10, 20) + (level - 1) * 5,
                AttackChance = Program.Rand.Next(Program.Rand.Next(30, 50) + (level - 1) * 5), // ??
                Defence = Program.Rand.Next(5, 10) + (level - 1) * 3,
                DefenceChance = Program.Rand.Next(Program.Rand.Next(30, 50) + (level - 1) * 5), // ??
                Gold = Program.Rand.Next(5, 20) + level * 3,
                Awarness = 10,
                Color = RLColor.Green,
                MaxHealth = health,
                Speed = 14
                
            };
            

        }
        /*public void Draw(RLConsole console)
        {
            if (this.Health > this.Health / 66)
            {
                console.Set(X, Y, Color, Colors.Colors.FloorBackgroundFov, Symbol);
            }
            else if (this.Health > this.Health / 33)
            {
                console.Set(X, Y, RLColor.Yellow, Colors.Colors.FloorBackgroundFov, Symbol);
            }
            else
            {
                console.Set(X, Y, RLColor.Red, Colors.Colors.FloorBackgroundFov, Symbol);
            }
        }*/
    }
}
