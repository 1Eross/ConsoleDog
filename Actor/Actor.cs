using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ConsoleDog.Interface;
using MessageLog;
using RLNET;

namespace ConsoleDog.Actor
{
    public class Actor : IActor, IDrowable
    {
        //IActor
        private int _attack;
        private int _attackChance;
        private int _defence;
        private int _defenceChance;
        private int _gold;
        private int _health;
        private int _maxhealth;
        private string _name;
        private int _speed;
        private int _awarness;

        //IDrowable
        public RLColor Color { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public int Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }
        public int AttackChance
        {
            get
            {
                return _attackChance;
            }
            set
            {
                _attackChance = value;
            }
        }
        public int Defence
        {
            get
            {
                return _defence;
            }
            set
            {
                _defence = value;
            }
        }
        public int DefenceChance
        {
            get
            {
                return _defenceChance;
            }
            set
            {
                _defenceChance = value;
            }
        }
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public int MaxHealth
        {
            get { return _maxhealth; }
            set
            {
                _maxhealth = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public int Awarness
        {
            get
            {
                return _awarness;
            }
            set
            {
                _awarness = value;
            }
        }

        public void Draw(RLConsole console)
        {
            console.Set(X, Y, Color, Colors.Colors.FloorBackgroundFov, Symbol);

            /*            if (!Map.GetCell(X, Y).IsExplored)
                        {
                            return;
                        }*/
            /*
                        if (Map.IsInFov(X, Y))
                        {
                            console.Set(X, Y, RLColor, Colors.Colors.FloorBackgroundFov, Symbol);
                        }
                        else
                        {
                            console.Set(X, Y, Colors.Colors.Floor, Colors.Colors.FloorBackground, '.');
                        }*/

        }
    }
}
