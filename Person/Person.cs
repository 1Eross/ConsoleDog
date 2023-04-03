using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Person
{
    public class Person
    {
        public string Name { get; set; }
        public char Icon { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Person(string name, int level, int health, int attack, int defense, char icon)
        {
            Name = name;//имя
            Icon = icon; //отображение на карте
            Level = level;//уровень
            Health = health;//здоровье
            Attack = attack;//атака
            Defense = defense;//защита
        }

        public void Damage(int damage)//урон
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public bool Dead()//смерть
        {
            return Health <= 0;
        }
    }
}
