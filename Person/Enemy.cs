using RogueSharp.Random;
using System;

namespace ConsoleDog.Person
{
    public class Enemy : Person
    {
        public int Experience { get; set; }
        public int Gold;
        private static Random random = new Random();
        public Enemy(string name, int level, int health, int attack, int defense, int experience, int gold, int playerX, int playerY, char icon) : base(name, level, health, attack, defense, playerX, playerY, icon)
        {
            name = ConsoleDog.Person.Logic_Enemies.GenerateName();
            icon = ConsoleDog.Person.Logic_Enemies.GenerateIcon();
            health = random.Next(30, 50) + (level - 1) * 10;
            attack = random.Next(10, 20) + (level - 1) * 5;
            defense = random.Next(5, 10) + (level - 1) * 3;
            experience = level * 10;
            gold = random.Next(5, 20) + level * 3;
            playerX = random.Next(0, 80);
            playerY = random.Next(0, 35);
            Experience = experience;
            Gold = gold;
        }

        public void AttackPlayer(Player player)
        {
            int damage = Attack - player.Defense;
            if (damage > 0)
            {
                player.Damage(damage);
                Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} attacks {player.Name} but fails to do any damage.");
            }
        }
    }
}
