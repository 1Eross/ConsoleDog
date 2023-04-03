using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleDog.Person
{
    public class Player : Person
    {
        public int Experience { get; set; }
        public int Gold { get; private set; }

        public int _PlayerX;
        public int _PlayerY;

        public Player(string name, int level, int health, int attack, int defense, int experience, int gold, int playerX, int playerY, char icon) : base(name, level, health, attack, defense, icon)
        {
            Experience = experience;
            icon = '@';
            Gold = gold;
            this._PlayerX = playerX;
            this._PlayerY = playerY;
        }

        public void AttackEnemy(Enemy enemy)
        {
            int damage = Attack - enemy.Defense;
            if (damage > 0)
            {
                enemy.Damage(damage);
                Console.WriteLine($"{Name} attacks {enemy.Name} for {damage} damage!");
                if (enemy.Dead())
                {
                    Console.WriteLine($"{enemy.Name} is defeated! {Experience} experience and {enemy.Experience} gold is received.");
                    GainExperience(enemy.Experience);
                    GainGold(enemy.Gold);
                }
            }
            else
            {
                Console.WriteLine($"{Name} attacks {enemy.Name} but fails to do any damage.");
            }
        }

        public void GainExperience(int experience)
        {
            Experience += experience;
            if (Experience >= Level * 10)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            Health += 10;
            Attack += 5;
            Defense += 5;
            Console.WriteLine($"{Name} leveled up to level {Level}!");
        }

        public void GainGold(int gold)
        {
            Gold += gold;
            Console.WriteLine($"{Name} gained {gold} gold.");
        }

        public void SpendGold(int gold)
        {
            Gold -= gold;
            Console.WriteLine($"{Name} spent {gold} gold.");
        }
    }
}
