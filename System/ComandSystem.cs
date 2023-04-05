using ConsoleDog.Actor;
using ConsoleDog.Core;
using ConsoleDog.Map;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.System
{
    public class ComandSystem
    {
        public bool MovePlayer(Direction direction)
        {
            int x = Program.Player.X;
            int y = Program.Player.Y;

            switch (direction)
            {
                case Direction.Down:
                    {
                        y = Program.Player.Y + 1; break;
                    }
                case Direction.Up:
                    {
                        y = Program.Player.Y - 1; break;
                    }
                case Direction.Left:
                    {
                        x = Program.Player.X - 1; break;
                    }
                case Direction.Right:
                    {
                        x = Program.Player.X + 1; break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (Map.Map.SetActorPosition(Program.Player, x, y))
            {
                return true;
            }

            Monster monster = Map.Map.GetMonsterAt(x,y);
            if (monster != null)
            {
                Attack(Program.Player, monster);
                return true;
            }

            return false;

        }
        public void Attack(Actor.Actor attacker, Actor.Actor defender) ///Неправильно
        {
            /*StringBuilder attackMessage = new StringBuilder();
            StringBuilder defenceMessage = new StringBuilder(); // Для лога*/
            int hits = ResolveAttack(attacker, defender);
            int blocks = ResolveDefence(defender, hits);
            
            /*Program.MessageLog.Add(attackMessage.ToString());*/
/*            if (!string.IsNullOrWhiteSpace(defenceMessage.ToString()))
            {
                Program.MessageLog.Add(defenceMessage.ToString());
            }*/

            int damage = (hits - blocks) * attacker.Attack;
            ResolveDamage(defender, damage);
        }
        private static int ResolveAttack(Actor.Actor attacker, Actor.Actor defender)//??
        {
            int hits = 0;

/*            attackMessage.AppendFormat("{0} attacks {1} and rolls: ", attacker.Name, defender.Name);*/
            
            if (attacker.AttackChance >= Program.Rand.NextDouble() * 100)
            {
                hits++;
            }
            return hits;
        }
        private static int ResolveDefence(Actor.Actor defender,int hits)//?
        {
            int blocks = 0;
/*
            attackMessage.AppendFormat("scoring {0} hits.", hits);
            defenceMessage.AppendFormat("  {0} defends and rolls: ", defender.Name);*/

            if (defender.DefenceChance >= Program.Rand.NextDouble() * 100)
            {
                blocks++;
            }
/*            defenceMessage.AppendFormat("resulting in {0} blocks.", blocks);*/
            return blocks;
        }
        private static void ResolveDamage(Actor.Actor defender, int damage)
        {
            if (damage > 0)
            {
                defender.Health -= damage;
                Program.MessageLog.Add($"  {defender.Name} was hit for {damage} damage");
                if (defender.Health < 0)
                {
                    ResolveDeath(defender);
                }
            }
            else
            {
                Program.MessageLog.Add($"  {defender.Name} blocked all damage");
            }
        }
        private static void ResolveDeath(Actor.Actor defender)
        {
            if (defender is Player)
            {
                Program.MessageLog.Add($"  {defender.Name} was killed, GAME OVER MAN!");
            }
            if(defender is Monster)
            {
                Map.Map.RemoveMonster((Monster) defender);
                Program.MessageLog.Add($"  {defender.Name} died and dropped {defender.Gold} gold");

            }
        }


    }
}
