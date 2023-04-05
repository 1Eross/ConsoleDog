using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Interface
{
    public interface IActor
    {
        int Attack { get; set; }
        int AttackChance { get; set; }
        int Defence { get; set; }
        int DefenceChance { get; set; }
        int Gold { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Speed { get; set; }
        string Name { get; }
        int Awarness { get; }

    }
}
