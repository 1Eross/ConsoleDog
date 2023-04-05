using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Actor
{
    public class Player : Actor
    {
        public Player() 
        {
            Attack = 50;
            AttackChance = 50;
            Awarness = 15;
            Name = "Dog";
            Color = Colors.Colors.Player;
            Symbol = '@';
            X = 5;
            Y = 5;
            Defence = 2;
            DefenceChance = 40;
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Speed = 10;
        }

        public void DrawStats(RLConsole statsConsole)
        {
            statsConsole.Print(1, 1, $"Name: {Name}", Colors.Colors.Text);
            statsConsole.Print(1, 3, $"Health: {Health}", Colors.Colors.Text);
            statsConsole.Print(1, 5, $"Attack: {Attack}", Colors.Colors.Text);
            statsConsole.Print(1, 7, $"Defence: {Defence}", Colors.Colors.Text);
            statsConsole.Print(1, 9, $"Gold: {Gold}", RLColor.Yellow);
        }
        /*public void UpdatePlayerFieldOfView() Нет fova, бесполезно
        {   
            Player player = Program.Player;

        }*/
    }
}
