using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Person
{
    internal class Person
    {
        public char Icon = '@';
        public int _PersonX;
        public int _PersonY;
        public Person(int personX, int personY)
        {
            this._PersonX = personX;
            this._PersonY = personY;
        }
    }
}
