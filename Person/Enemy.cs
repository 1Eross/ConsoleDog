using System;

namespace ConsoleDog.Person
{
    public class Enemy : Person
    {
        public int Experience { get; set; }
        public int Gold;
        public Enemy(string name, int level, int health, int attack, int defense, int experience, int gold, char icon) : base(name, level, health, attack, defense, icon)
        {
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
