using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Person
{
    public static class Logic_Enemies
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
            return new Enemy(name, level, health, attack, defense, experience, gold, icon);
        }

        private static string GenerateName()//случайная генерация имён
        {
            string[] names = { "Goblin", "Orc", "Troll", "Skeleton", "Zombie", "Wraith" };//массив имён
            return names[random.Next(0, names.Length)];
        }
        private static char GenerateIcon()//случайная генерация иконок
        {
            char[] icon = { 'G', 'O', 'T', 'S', 'Z', 'W' };//массив символов отображения врагов
            return icon[random.Next(0, icon.Length)];
        }
    }
}
