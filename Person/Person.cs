using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageLog;

namespace ConsoleDog.Person
{
    public class Person
    {
        public string _Name { get; set; }
        public char _Icon { get; set; }
        public int _Level { get; set; }
        public int _Health { get; set; }
        public int _Attack { get; set; }
        public int _Defense { get; set; }
        public int _PlayerX { get; set; }
        public int _PlayerY { get; set; }

        public Person(string name, int level, int health, int attack, int defense, int playerX, int playerY, char icon)
        {
            _Name = name;//имя
            _Icon = icon; //отображение на карте
            _Level = level;//уровень
            _Health = health;//здоровье
            _Attack = attack;//атака
            _Defense = defense;//защита
            _PlayerX = playerX;
            _PlayerY = playerY;
        }

        public void Damage(int damage)//урон по нам
        {
            _Health -= damage;
            if (_Health < 0)
            {
                _Health = 0;
            }
        }

        public bool Dead()//смерть
        {
            return _Health <= 0;
        }
    }
    public class Enemy_Factory
    {
        private static Random random = new Random();

        public static Enemy CreateEnemy(int level)//создание врагов
        {
            string name = GenerateName();
            char icon = GenerateIcon();
            int health = random.Next(30, 50) + (level - 1) * 10;
            int attack = random.Next(10, 20) + (level - 1) * 5;
            int defense = random.Next(5, 10) + (level - 1) * 3;
            int experience = level * 10;
            int gold = random.Next(5, 20) + level * 3;
            int EnemyX = random.Next(0, 80);
            int EnemyY = random.Next(0, 35);
            return new Enemy(name, level, health, attack, defense, experience, gold, EnemyX, EnemyY, icon);
        }

        public static string GenerateName()//случайная генерация имён
        {
            string[] names = { "Goblin", "Orc", "Troll", "Skeleton", "Zombie", "Wraith" };//массив имён
            return names[random.Next(0, names.Length)];
        }
        public static char GenerateIcon()//случайная генерация иконок
        {
            char[] icon = { 'G', 'O', 'T', 'S', 'Z', 'W' };//массив символов отображения врагов
            return icon[random.Next(0, icon.Length)];
        }
    }
    public class Enemy : Person
    {
        public int Experience { get; set; }
        public int Gold;
        private static Random random = new Random();
        public Enemy(string name, int level, int health, int attack, int defense, int experience, int gold, int playerX, int playerY, char icon) : base(name, level, health, attack, defense, playerX, playerY, icon)
        {
            name = ConsoleDog.Person.Enemy_Factory.GenerateName();
            icon = ConsoleDog.Person.Enemy_Factory.GenerateIcon();
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
            int damage = _Attack - player._Defense;
            if (damage > 0)
            {
                player.Damage(damage);
                MessageLog.MessageLog.Add($"{_Name} attacks {player._Name} for {damage} damage!");
            }
            else
            {
                MessageLog.MessageLog.Add($"{_Name} attacks {player._Name} but fails to do any damage.");
            }
        }
    }
    public class Player : Person
    {
        public int _Experience { get; set; }
        public int _Gold { get; private set; }


        public Player(string name, int level, int health, int attack, int defense, int experience, int gold, int playerX, int playerY, char icon) : base(name, level, health, attack, defense, playerX, playerY, icon)
        {
            _Experience = experience;
            icon = '@';
            _Gold = gold;
            this._PlayerX = playerX;
            this._PlayerY = playerY;
        }

        public void AttackEnemy(Enemy enemy)
        {
            int damage = _Attack - enemy._Defense;
            if (damage > 0)
            {
                enemy.Damage(damage);
                MessageLog.MessageLog.Add($"{_Name} attacks {enemy._Name} for {damage} damage!");
                if (enemy.Dead())
                {
                    MessageLog.MessageLog.Add($"{enemy._Name} is defeated! {_Experience} experience and {enemy.Experience} gold is received.");
                    GainExperience(enemy.Experience);
                    GainGold(enemy.Gold);
                }
            }
            else
            {
                MessageLog.MessageLog.Add($"{_Name} attacks {enemy._Name} but fails to do any damage.");
            }
        }

        public void GainExperience(int experience)
        {
            _Experience += experience;
            if (_Experience >= _Level * 10)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            _Level++;
            _Health += 10;
            _Attack += 5;
            _Defense += 5;
            MessageLog.MessageLog.Add($"{_Name} leveled up to level {_Level}!");
        }

        public void GainGold(int gold)
        {
            _Gold += gold;
            MessageLog.MessageLog.Add($"{_Name} gained {gold} gold.");
        }

        public void SpendGold(int gold)
        {
            _Gold -= gold;
            MessageLog.MessageLog.Add($"{_Name} spent {gold} gold.");
        }
    }
}
